using TaskManagementAPI.Entities;

namespace TaskManagementAPI.Models
{
    public class ReportResponse
    {
        public string TeamName { get; set; } = string.Empty;

        public int CompletedStories { get; set; }

        public int IncompletedStories { get; set; }

    }
}
