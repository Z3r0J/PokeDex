using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Application.ViewModel
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Color { get; set; }
        public string RegionName { get; set; }
        public string FirstTypeName { get; set; }
        public string SecondTypeName { get; set; }

    }
}
