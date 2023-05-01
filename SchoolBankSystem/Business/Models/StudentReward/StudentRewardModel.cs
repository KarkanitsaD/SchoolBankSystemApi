using Business.Models.Reward;
using Business.Models.Student;
using Business.Models.Teacher;

namespace Business.Models.StudentReward
{
    public class StudentRewardModel
    {
        public Guid Id { get; set; }

        public decimal Sum { get; set; }

        public Guid RewardId { get; set; }

        public RewardModel Reward { get; set; }

        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

        public TeacherModel Teacher { get; set; }

        public DateTime Time { get; set; }
    }
}