namespace Business.Models.Teacher
{
    public class AuthenticationTeacherModel
    {
        public AuthenticationTeacherModel(TeacherModel teacher, string jwt)
        {
            Teacher = teacher;
            Jwt = jwt;
        }

        public TeacherModel Teacher { get; set; }

        public string Jwt { get; set; }
    }
}