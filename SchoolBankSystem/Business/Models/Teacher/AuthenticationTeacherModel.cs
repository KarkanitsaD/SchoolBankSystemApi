namespace Business.Models.Teacher
{
    public class AuthenticationTeacherModel
    {
        public string Jwt { get; set; }

        public TeacherModel Teacher { get; set; }
    }
}