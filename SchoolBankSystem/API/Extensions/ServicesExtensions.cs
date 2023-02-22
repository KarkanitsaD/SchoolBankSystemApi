using Business.Constants;
using Business.Services;
using Business.Services.IServices;
using DAL;
using DAL.Repositories;
using DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(TokenService).Assembly)
                .AddScoped(typeof(ITokenService), typeof(TokenService))
                .AddScoped(typeof(IAuthService), typeof(AuthService))
                ;

            return services;
        }

        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SchoolBankSystemDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                ;

            return services;
        }

        public static IServiceCollection AddAppAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("CS:GO-TheBestGameInTheWorld")),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        public static IServiceCollection AddAppAuthorization(this IServiceCollection services)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(Roles.Student, policy => policy.RequireRole(Roles.Student));
                    options.AddPolicy(Roles.Teacher, policy => policy.RequireRole(Roles.Teacher));
                    options.AddPolicy(Roles.Student, policy => policy.RequireRole(Roles.Student));
                });

            return services;
        }
    }
}