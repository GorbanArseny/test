using Izuran.Shared.Entities;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace Izuran.Authentication
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "Yc2E4wqNiPyA4FEmkh3PMoa96s9rpR626PXgnfs2i6IaIObeVq";
        private const int JWT_TOKEN_VALIDITY_MINS = 180;

        private UserAccountService _userAccountService;
        public JwtAuthenticationManager(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        public UserSession? GenerateJwtToken(string UserName,string password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(password))
                return null;
            //
            var userAccount = _userAccountService.GetUserAccountByUserName(UserName);
            if (userAccount==null||userAccount.Password !=password) 
                return null;
            // генерация токена
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userAccount.UserName),
                    new Claim(ClaimTypes.NameIdentifier,userAccount.Id.ToString())
                });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            //объекь сеанса пользователя
            var userSession = new UserSession
            {
                UserName = userAccount.UserName,
                Id = userAccount.Id,
                Token = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
            return userSession;
        }
    }
    
}
