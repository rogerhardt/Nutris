using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutris.Models
{
    public class PlanoAlimentarViewModel
    {
        public PlanoAlimentar PlanoAlimentar { get; set; }
        public List<ItemPlanoAlimentar> items { get; set; }
    }
}