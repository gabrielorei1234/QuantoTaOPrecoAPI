using Microsoft.AspNetCore.Mvc;
using QuantoTaOPrecoAPI.Data;
using QuantoTaOPrecoAPI.Models;

namespace QuantoTaOPrecoAPI.Services
{
    public class UsuarioService
    {
        public dbquantotaoprecoContext _context;

        public UsuarioService(dbquantotaoprecoContext context)
        {
            _context = context;
        }

        public IActionResult AdicionaUsuario(Usuario model)
        {
            DateOnly on = DateOnly.FromDateTime( model.DataDeNascimento);            
            _context.Add(model);
            _context.SaveChanges();
            return null;
        }
    }

}
