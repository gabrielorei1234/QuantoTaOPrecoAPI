using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Empresasprodutos = new HashSet<Empresasproduto>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? IdUnidadesDeMedida { get; set; }

        public virtual Unidadesdemedidum? IdUnidadesDeMedidaNavigation { get; set; }
        public virtual ICollection<Empresasproduto> Empresasprodutos { get; set; }
    }
}
