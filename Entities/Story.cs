namespace TaskManagementAPI.Entities
{
    public class Story
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<string> DocumentPath { get; set;}

        public List<string> Notes { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; } = string.Empty;

        public int TeamId { get; set; }

        public int EmployeeId { get; set; }

        public int ManagerId { get; set; }
    }
}
