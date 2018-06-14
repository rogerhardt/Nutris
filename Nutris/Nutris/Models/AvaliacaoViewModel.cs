using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutris.Models
{
    public class AvaliacaoViewModel
    {
        public Avaliacao Avaliacao { get; set; }
        public DateTime Data { get; set; }
        public string loginPaciente { get; set; }
        public string loginNutricionista { get; set; }
    }
}