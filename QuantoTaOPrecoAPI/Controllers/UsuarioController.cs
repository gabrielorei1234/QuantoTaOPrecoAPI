using Microsoft.AspNetCore.Mvc;
using QuantoTaOPrecoAPI.Models;
using QuantoTaOPrecoAPI.Services;

namespace QuantoTaOPrecoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _suarioService;
        
        public UsuarioController(UsuarioService usuarioService)
        {
            _suarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult AdicionaUsuario(Usuario model)
        {
            _suarioService.AdicionaUsuario(model);
            return Ok();
        }

    }
}
