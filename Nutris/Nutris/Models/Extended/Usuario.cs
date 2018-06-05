using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nutris.Models
{
    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuario
    {
    }

    public class UsuarioMetadata
    {
        [Display(Name = "Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login required")]
        public string login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string password { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Usuário Nutricionista")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Necessário informar se é nutricionista ou não")]
        public bool nutricionista { get; set; }

    }
}