using AutoMapper;
using Business.Models.Auth;
using Business.Models.Student;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentModel>().ForMember(x => x.MoneyTransfers, act => act.MapFrom(x => JoinTransfers(x)));
            CreateMap<RegisterModel, Student>();
        }

        private List<MoneyTransfer>? JoinTransfers(Student student)
        {
            List<MoneyTransfer>? result = null;

            if (student.MoneyTransfersFromStudent != null && student.MoneyTransfersToStudent != null)
            {
                student.MoneyTransfersFromStudent.AddRange(student.MoneyTransfersToStudent);
                result = student.MoneyTransfersFromStudent.OrderByDescending(x => x.Time).ToList();
            }

            return result;
        }
    }
}