﻿namespace TaskManagementAPI.Entities
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int ManagerId { get; set; }
    }
}
