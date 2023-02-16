namespace Business.Services.IServices;

public interface ITokenService
{
    string GenerateJwt(string role);
}