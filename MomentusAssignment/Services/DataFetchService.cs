namespace MomentusAssignment.Services;

public class DataFetchService : IDataFetchService
{
    private const string rootApiUrl = "https://jsonplaceholder.typicode.com/";

    private readonly HttpClient httpClient;

    private readonly IWebHostEnvironment webHostEnvironment;

    private readonly string rootDataPath;

    public DataFetchService(HttpClient httpClient, IWebHostEnvironment webHostEnvironment)
    {
        this.httpClient = httpClient;
        this.webHostEnvironment = webHostEnvironment;

        rootDataPath = $"{this.webHostEnvironment.ContentRootPath}/JsonData";
    }

    public async Task GetAllData(bool recreateFile = false)
    {
        if (!Directory.Exists(rootDataPath))
        {
            Directory.CreateDirectory(rootDataPath);
        }

        var dataTypes = new string[] { "users", "posts", "comments" };

        foreach (var dataType in dataTypes)
        {
            var url = $"{rootApiUrl}{dataType}";
            var data = await FetchData(url);

            if (data != null)
            {
                await WriteDataToFile(data, dataType);
            }
        }
    }

    private async Task<string?> FetchData(string url)
    {
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            return null;
        }  
    }

    private async Task WriteDataToFile(string jsonData, string dataType, bool recreateFile = false)
    {
        if (string.IsNullOrWhiteSpace(jsonData))
        {
            return;
        }

        var fileName = $"{dataType}.json";
        var filePath = $"{rootDataPath}/{fileName}";

        if (recreateFile && File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            await File.WriteAllTextAsync(filePath, jsonData);
        }
    }
}
