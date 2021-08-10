using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02.Models
{
    public class ClientEditModel
    {
        public Guid ClientID { get; set; }
        // The '{1}' is used to refer the number, like used in arrays.
        // Using one the code knows, that it should take te value of frist
        // position, in this case 6 and 150
        [MinLength(6, ErrorMessage = "Please, enter at least with {1} characters.")]
        [MaxLength(150, ErrorMessage = "Please, enter a maximum of {1} characters.")]
        [Required(ErrorMessage = "Please, enter with client's name.")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please, enter with a valid email.")]
        [Required(ErrorMessage = "Please, enter with client's email.")]
        public string Email { get; set; }
    }
}
