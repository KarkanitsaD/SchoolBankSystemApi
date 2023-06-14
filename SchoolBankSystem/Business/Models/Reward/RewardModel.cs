namespace Business.Models.Reward
{
    public class RewardModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal Sum { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}