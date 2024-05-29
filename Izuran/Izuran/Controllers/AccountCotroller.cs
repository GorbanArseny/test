using Izuran.Authentication;
using Izuran.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Izuran.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AccountCotroller : ControllerBase
    {
        private UserAccountService _userAccountService;

        public AccountCotroller(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
            var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserName, loginRequest.Password);
            if (userSession is null)
                return Unauthorized();
            else
                return userSession;
        }
    }
}
