using Gerenciador_Cursos.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticadorController : ControllerBase
    {

        private readonly ConfiguracoesJWT configuracoesJWT;
        public AutenticadorController(IOptions<ConfiguracoesJWT> opcoes) 
        {
            configuracoesJWT = opcoes.Value;
        }

        [HttpGet]
        public IActionResult ObtertToken()
        {
            var token = GerarToken();

            var retorno = new
            {
               token = token
            };
            return Ok(retorno);

        }
        private string GerarToken()
                        
        {
            IList<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Gerente"));

            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuracoesJWT.Segredo)),SecurityAlgorithms.HmacSha256Signature),
                Audience = "https://localhost:5001",
                Issuer = "Bootcamp2022",
                Subject = new ClaimsIdentity(claims),
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            handler.WriteToken(token);
            return handler.WriteToken(token);
        }
    }
}
