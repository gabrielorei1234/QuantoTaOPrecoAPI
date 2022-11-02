using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Unidadesdemedidum
    {
        public Unidadesdemedidum()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
