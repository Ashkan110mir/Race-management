namespace Race_management.Models
{
    public class Show
    {
        public int ShowId { get; set; }

        public string? ShowTitle { get; set; }

        public DateTime ShowDate { get; set; }

        public int AverageScore { get; set; }

        public RmUserIdentity? ShowPlayer { get; set;}

        public List<ShowToCoach>? ShowToCoach { get; set; }

        
    }
}
