using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZicGooFriendsWeb.Models;
using ZicGooFriendsWeb.Services;

namespace ZicGooFriendsWeb.APIs
{
    public static class AuthenticationApi
    {
        public static void ConfigureAuthenticationApi(this WebApplication app)
        {
            app.MapPost("/login", Login);
        }

        private static async Task<IResult> Login(UserModel user, IUserDao userDao, IConfiguration config)
        {
            try
            {
                List<UserModel> result = await userDao.GetUserByAccountPw(user.AccountID,user.Password);
                if (result is null)
                {
                    return Results.NotFound("User not found");
                }

                UserModel registeredUser = result.First<UserModel>();

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,registeredUser.AccountID),
                    new Claim(ClaimTypes.Email,registeredUser.Email),
                    new Claim(ClaimTypes.Name,registeredUser.NickName),
                    new Claim(ClaimTypes.Role,registeredUser.Role)
                };

                JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: config["Jwt:Issuer"],
                    audience: config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                            SecurityAlgorithms.HmacSha256
                        )
                );

                string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
                return Results.Ok(tokenStr);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
