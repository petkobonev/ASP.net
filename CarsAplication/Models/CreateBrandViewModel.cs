using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class CreateBrandViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }

        public CreateBrandViewModel() { }

        public CreateBrandViewModel(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}