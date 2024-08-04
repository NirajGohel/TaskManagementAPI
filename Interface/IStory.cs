using TaskManagementAPI.Entities;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interface
{
    public interface IStory
    {
        Task<List<Story>> GetAllStories();

        Task<Story> GetStoryById(int id);

        Task<Story> AddStory(Story task);

        Task<Story> UpdateStory(Story task);

        Task<Story> DeleteStory(int id);

        Task<List<Response>> GetStoriesByManager(int managerId);

        Task<List<ReportResponse>> GetReport(DateTime dueDate);
    }
}
