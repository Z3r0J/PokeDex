using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.ViewModel
{
    public class AddTypeViewModel
    {
        public int TypeId { get; set; }
        [Required(ErrorMessage = "The name is required Ex. Water")]
        public string Name { get; set; }
    }
}
