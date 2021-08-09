using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02.Models
{
    public class ClientConsultModel
    {
        [MinLength(3, ErrorMessage = "Please, enter at least with {1} characters.")]
        [MaxLength(150, ErrorMessage = "Please, enter a maximum of {1} characters.")]
        [Required(ErrorMessage = "Please, enter with client's name.")]
        public string Name { get; set; }
    }
}
