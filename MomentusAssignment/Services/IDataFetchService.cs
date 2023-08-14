namespace MomentusAssignment.Services;

public interface IDataFetchService
{
    Task GetAllData(bool recreateFile = false);
}