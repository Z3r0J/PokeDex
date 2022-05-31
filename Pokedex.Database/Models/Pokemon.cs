using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Color { get; set; }

        //Navigation Properties
        public int RegionId { get; set; }
        public Region Region { get; set; }

        //Navigation Properties
        public int PrimaryTypeId { get; set; }
        public Type PrimaryType { get; set; }

        //Navigation Properties
        public int SecondaryTypeId { get; set; }
        public Type SecondaryType { get; set; }


    }
}
