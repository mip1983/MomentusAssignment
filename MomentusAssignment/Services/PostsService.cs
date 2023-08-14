using MomentusAssignment.Model;
using System.Text.Json;

namespace MomentusAssignment.Services;

public class PostsService
{
    private readonly string _rootDataPath;
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly string rootDataPath;

    private List<Post> posts;


    public PostsService(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;

        this.rootDataPath = $"{this.webHostEnvironment.ContentRootPath}/JsonData";
    }

    public async Task LoadPostsData()
    {
        // Load posts from json file as stream
        var path = $"{this.rootDataPath}/posts.json";
        var fileContentStream = File.OpenRead(path) ?? throw new Exception("File not found");

        var posts = await JsonSerializer.DeserializeAsync<List<Post>>(fileContentStream);

        if (posts != null)
        {
            this.posts = posts;
        }
    }
}
