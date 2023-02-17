namespace Business.Models.Student
{
    public class AuthenticationStudentModel
    {
        public AuthenticationStudentModel(StudentModel student, string jwt)
        {
            Student = student;
            Jwt = jwt;
        }

        public StudentModel Student { get; }

        public string Jwt { get; }
    }
}