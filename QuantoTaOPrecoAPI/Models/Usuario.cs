using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Historicoprodutos = new HashSet<Historicoproduto>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public DateTime DataDeNascimento { get; set; }

        public virtual ICollection<Historicoproduto> Historicoprodutos { get; set; }
    }
}
