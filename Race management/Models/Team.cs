﻿namespace Race_management.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public string? TeamName { get; set; }

        public List<RmUserIdentity>? Player { get; set; }
    }
}
