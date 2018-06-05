using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nutris.Models
{
    public class UsuarioLogin
    {
        [Display(Name = "Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login required")]
        public string login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string password { get; set; }

        [Display(Name = "Lembrar Usuário")]
        public bool rememberMe { get; set; }
    }
}