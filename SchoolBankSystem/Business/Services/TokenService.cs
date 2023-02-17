using Business.Models.Student;
using Business.Models.Teacher;
using Business.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class TokenService : ITokenService
    {
        private const string SecretKey = "CS:GO";

        public string GenerateStudentJwt(StudentModel student)
        {
            var claims = GetStudentClaims(student);
            var credentials = GetSigningCredentials();
            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Date.AddSeconds(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateTeacherJwt(TeacherModel teacher)
        {
            var claims = GetTeacherClaims(teacher);
            var credentials = GetSigningCredentials();
            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Date.AddSeconds(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private List<Claim> GetStudentClaims(StudentModel student)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, student.Phone),
                new Claim(ClaimTypes.Role, "Student")
            };
        }

        private List<Claim> GetTeacherClaims(TeacherModel student)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, student.Phone),
                new Claim(ClaimTypes.Role, "Teacher")
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}