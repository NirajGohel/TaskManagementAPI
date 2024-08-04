using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Interface;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories
{
    public class StoryRepository : IStory
    {
        private readonly DataContext _context; 

        public StoryRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<Story> AddStory(Story story)
        {
            var res = _context.Stories.AddAsync(story);
            if (res.IsCompleted)
            {
                await _context.SaveChangesAsync();
            }

            return story;
        }

        public async Task<Story> DeleteStory(int id)
        {
            var dbStory = await _context.Stories.FindAsync(id);

            if (dbStory == null)
            {
                return new Story();
            }

            _context.Stories.Remove(dbStory);
            await _context.SaveChangesAsync();

            return dbStory;
        }

        public async Task<List<Story>> GetAllStories()
        {
            var stories = await _context.Stories.ToListAsync();
            return stories;
        }

        public async Task<Story> GetStoryById(int id)
        {
            var story = await _context.Stories.FindAsync(id);

            if (story == null)
            {
                return new Story();
            }

            return story;
        }

        public async Task<Story> UpdateStory(Story updatedStory)
        {
            var dbStory = await _context.Stories.FindAsync(updatedStory.Id);

            if (dbStory == null)
            {
                return new Story();
            }

            dbStory.Title = updatedStory.Title;
            dbStory.Description = updatedStory.Description;
            dbStory.Priority = updatedStory.Priority;
            dbStory.DocumentPath = updatedStory.DocumentPath;
            dbStory.DueDate = updatedStory.DueDate;
            dbStory.Notes = updatedStory.Notes;
            dbStory.IsCompleted = updatedStory.IsCompleted;
            dbStory.EmployeeId = updatedStory.EmployeeId;
            dbStory.ManagerId = updatedStory.ManagerId;
            dbStory.TeamId = updatedStory.TeamId;

            await _context.SaveChangesAsync();
            return dbStory;
        }

        public async Task<List<Response>> GetStoriesByManager(int managerId)
        {
            var response = await (from s in _context.Stories
                           join e in _context.Employees
                           on s.EmployeeId equals e.Id
                           where s.ManagerId == managerId
                           select new Response
                           {
                               story = s,
                               employee = e,
                           }).ToListAsync();            
            
            return response;
        }

        public async Task<List<ReportResponse>> GetReport(DateTime dueDate)
        {
            var response = await (from t in _context.Teams
                                  join s in _context.Stories
                                  on t.Id equals s.TeamId
                                  where s.DueDate <= dueDate
                                  group s by new { t.Id, t.Name } into teamGroup
                                  select new ReportResponse
                                  {
                                      TeamName = teamGroup.Key.Name,
                                      CompletedStories = teamGroup.Count(s => s.IsCompleted),
                                      IncompletedStories = teamGroup.Count(s => !s.IsCompleted)
                                  }

                            ).ToListAsync();
            
            return response;
        }
    }
}
