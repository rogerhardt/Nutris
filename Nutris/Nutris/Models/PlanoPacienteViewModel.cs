using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutris.Models
{
    public class PlanoPacienteViewModel
    {
        public PlanoAlimentar PlanoAlimentar { get; set; }
        public List<PlanoPaciente> Pacientes { get; set; }
    }
}