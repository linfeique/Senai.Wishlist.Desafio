using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Wishlist.API.Domains;
using Senai.Wishlist.API.Interfaces;
using Senai.Wishlist.API.Repositories;

namespace Senai.Wishlist.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository usuarioRepositorio { get; set; }

        public UsuariosController()
        {
            usuarioRepositorio = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(usuarioRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest("Deu bug");
            }
        }

        [HttpPost]
        public IActionResult CadastrarUsuarios(Usuarios usuario)
        {
            try
            {
                usuarioRepositorio.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Deletar(int id)
        {
            try
            {
                usuarioRepositorio.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}