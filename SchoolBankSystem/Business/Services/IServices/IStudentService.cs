﻿using Business.Models.Student;

namespace Business.Services.IServices
{
    public interface IStudentService
    {
        Task<StudentModel> GetAsync(Guid id);

        Task<List<StudentModel>> GetAllAsync(StudentFilterModel studentFilterModel);

        Task UpdateAsync(StudentModel student);

        Task DeleteAsync(Guid id);
    }
}