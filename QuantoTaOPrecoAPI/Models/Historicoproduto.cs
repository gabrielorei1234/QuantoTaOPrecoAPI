using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Historicoproduto
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEmpresasProdutos { get; set; }
        public DateTime? DataRegistro { get; set; }

        public virtual Empresasproduto? IdEmpresasProdutosNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
