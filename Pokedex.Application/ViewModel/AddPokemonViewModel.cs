using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="Name is required. Ex. Pikachu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Photo Url is required. Ex. https://images.contoso.com/image.png")]
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="Pokemon color is Required Ex. Pikachu is Yellow")]
        public string Color { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The Region is required ex. Kanto")]
        public int RegionId { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="The Type is required Ex. Water")]
        public int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }

        //Select List for DropDown

        public SelectList Region { get; set; }
        public SelectList Type { get; set; }

    }
}
