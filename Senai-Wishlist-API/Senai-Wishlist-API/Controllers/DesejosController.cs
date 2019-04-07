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
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class DesejosController : ControllerBase
    {

        private IDesejoRepository desejoRepositorio { get; set; }
        private IUsuarioRepository usuarioRepositorio { get; set; }

        public DesejosController()
        {
            desejoRepositorio = new DesejoRepository();
            usuarioRepositorio = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarDesejos()
        {
            try
            {

                int id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                Usuarios usuarioProc = usuarioRepositorio.BuscarPorId(id);

                if (usuarioProc == null)
                {
                    return BadRequest();
                }

                return Ok(desejoRepositorio.Listar().Where(x => x.Id == usuarioProc.Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CadastrarDesejo(Desejos desejo)
        {
            try
            {
                desejo.DataCriacao = DateTime.Now;
                desejoRepositorio.Cadastrar(desejo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletarDesejo(int id)
        {
            try
            {
                desejoRepositorio.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}