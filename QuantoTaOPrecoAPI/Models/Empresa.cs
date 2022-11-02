using System;
using System.Collections.Generic;

namespace QuantoTaOPrecoAPI.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Empresasprodutos = new HashSet<Empresasproduto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int? Cnpj { get; set; }
        public int? Cep { get; set; }
        public int? IdEmpresaMatriz { get; set; }

        public virtual Empresamatriz? IdEmpresaMatrizNavigation { get; set; }
        public virtual ICollection<Empresasproduto> Empresasprodutos { get; set; }
    }
}
