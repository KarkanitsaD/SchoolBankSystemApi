namespace DAL.Entities;

public class StudentReward : Transaction
{
    public Guid Id { get; set; }

    public decimal Sum { get; set; }

    public Guid RewardId { get; set; }

    public Reward Reward { get; set; }

    public Guid StudentId { get; set; }

    public Student Student { get; set; }

    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; }
}