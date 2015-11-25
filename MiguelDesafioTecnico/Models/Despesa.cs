using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiguelDesafioTecnico.Models
{
    public class Despesa
    {

        [Key]
        public int DespesaId { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public string Data { get; set; }
        public string Observacao { get; set; }
    }
}