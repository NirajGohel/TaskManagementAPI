using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public int ManagerId { get; set; }

        public int TeamId { get; set; }

        public bool IsAdmin { get; set; }
    }
}
