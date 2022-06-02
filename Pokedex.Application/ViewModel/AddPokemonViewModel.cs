using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pokedex.Application.ViewModel
{
    public class AddPokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Color { get; set; }
        public int RegionId { get; set; }
        public int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }

        //Select List for DropDown

        public SelectList Region { get; set; }
        public SelectList Type { get; set; }

    }
}
