using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Empresamatriz
    {
        public Empresamatriz()
        {
            Empresas = new HashSet<Empresa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int? Cnpj { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
