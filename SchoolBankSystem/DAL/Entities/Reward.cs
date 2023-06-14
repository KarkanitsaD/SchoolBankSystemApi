namespace DAL.Entities;

public class Reward : CreateUpdateTimeEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public decimal Sum { get; set; }

    public bool IsDeleted { get; set; }

    public List<StudentReward> StudentRewards { get; set; }
}