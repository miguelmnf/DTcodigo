using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiguelDesafioTecnico.Models
{
    public class Relatorio
    {
        [Key]
        public int RelatorioId { get; set; }
        public List<Receita> receitas { get; set; }
        public List<Despesa> despesas { get; set; }

    }
}