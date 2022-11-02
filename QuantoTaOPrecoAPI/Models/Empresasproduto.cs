using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Empresasproduto
    {
        public Empresasproduto()
        {
            Historicoprodutos = new HashSet<Historicoproduto>();
        }

        public int Id { get; set; }
        public int? IdEmpresas { get; set; }
        public int? IdProdutos { get; set; }
        public decimal? Preco { get; set; }

        public virtual Empresa? IdEmpresasNavigation { get; set; }
        public virtual Produto? IdProdutosNavigation { get; set; }
        public virtual ICollection<Historicoproduto> Historicoprodutos { get; set; }
    }
}
