using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pokemon> PimaryType { get; set; }
        public ICollection<Pokemon> SecondaryType { get; set; }

    }
}
