namespace Business.Models.Student
{
    public class AuthenticationStudentModel
    {
        public string Jwt { get; set; }

        public StudentModel Student { get; set; }
    }
}