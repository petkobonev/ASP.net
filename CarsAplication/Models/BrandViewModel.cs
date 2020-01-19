using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class BrandViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int ID { get; set; }

        public BrandViewModel(Brand brand)
        {
            Name = brand.Name;
            Country = brand.Country;
            ID = brand.ID;

        }

        public BrandViewModel() { }

    }
}