namespace DAL.Entities;

public class Teacher : User
{
    public List<StudentReward> StudentRewards { get; set; }
}