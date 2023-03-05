using AutoMapper;
using Business.Models.StudentReward;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Services
{
    public class StudentRewardService : IStudentRewardService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<StudentReward> _studentRewardRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Reward> _rewardRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public StudentRewardService
        (
            IMapper mapper,
            IRepository<StudentReward> studentRewardRepository,
            IRepository<Student> studentRepository,
            IRepository<Reward> rewardRepository,
            IHttpContextAccessor contextAccessor
        )
        {
            _mapper = mapper;
            _studentRewardRepository = studentRewardRepository;
            _studentRepository = studentRepository;
            _rewardRepository = rewardRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<StudentRewardModel> RewardStudentAsync(RewardStudentModel rewardStudentModel)
        {
            var student = await _studentRepository.GetFirstAsync(x => x.Id == rewardStudentModel.StudentId);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            var reward = await _rewardRepository.GetFirstAsync(x => x.Id == rewardStudentModel.RewardId);
            if (reward == null)
            {
                throw new Exception("Reward not found.");
            }

            var teacherIdClaim = _contextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var teacherId = new Guid(teacherIdClaim.Value);

            var transaction = await _studentRepository.BeginTransactionAsync();

            student.Sum += reward.Sum;
            var studentReward = new StudentReward
            {
                StudentId = rewardStudentModel.StudentId,
                TeacherId = teacherId
            };

            await _studentRewardRepository.CreateAsync(studentReward);
            await _studentRepository.UpdateAsync(student);

            await transaction.CommitAsync();

            var studentRewardModel = _mapper.Map<StudentReward, StudentRewardModel>(studentReward);

            return studentRewardModel;
        }
    }
}
