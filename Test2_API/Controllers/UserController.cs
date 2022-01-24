using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Test2_API.Auth;
using Test2_API.database;
using Test2_API.model.Auth;

namespace Test2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private EfModel _efModel;

        public UserController(EfModel model)
        {
            _efModel = model;
        }

        [HttpPost("/token")]
        public ActionResult<object> Token(string username, string password) 
        {
            var indentity = GetIdentity(username, password);

            if (indentity == null)
            {
                return BadRequest();
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    audience: TokenBaseOptions.AUDIENCE,
                    issuer: TokenBaseOptions.ISSUER,
                    notBefore: now,
                    claims: indentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(TokenBaseOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(TokenBaseOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = indentity.Name
            };

            return response;
        }

        [NonAction]
        private ClaimsIdentity GetIdentity(string login, string password) 
        {
            User user = _efModel.user.FirstOrDefault(x => x.Login == login && x.Password == password);
            
            if (user == null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.FIO),
                    new Claim("UserId", user.UserId.ToString())
                };

                ClaimsIdentity claimsIdentity  = 
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            return null;
        }

        [Authorize]
        [HttpGet("/getuser")]
        public async Task<ActionResult<User>> getUserAcync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                throw new Exception("Identity пустой");
            return await _efModel.user.FindAsync(Convert.ToInt32(identity.FindFirst("UserId").Value));
        }
    }
}