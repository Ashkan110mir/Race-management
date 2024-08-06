namespace Race_management.Models
{
    public class ShowToCoach
    {
        
        public string? Coachid { get; set; }
        public RmUserIdentity? Coach { get; set; }

        public int? ShowId { get; set; }
        public Show? Show { get; set; }

        public int score { get; set; }
    }
}
