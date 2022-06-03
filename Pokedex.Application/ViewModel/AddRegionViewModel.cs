using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.ViewModel
{
    public class AddRegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Name is required. Ex. Kanto")]
        public string Name { get; set; }
    }
}
