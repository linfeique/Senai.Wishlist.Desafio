using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Wishlist.API.Domains;
using Senai.Wishlist.API.Interfaces;
using Senai.Wishlist.API.Repositories;
using Senai.Wishlist.API.ViewModels;

namespace Senai.Wishlist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository usuarioRepositorio { get; set; }

        public LoginController()
        {
            usuarioRepositorio = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult login(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = usuarioRepositorio.BuscarPorEmailESenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wishlist-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Wishlist.WebApi",
                    audience: "Wishlist.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}