using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class ModelViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public BrandViewModel Brand { get; set; }

        public ModelViewModel() { }
        public ModelViewModel(int id, string name, Brand brand)
        {
            ID = id;
            Name = name;
            Brand = new BrandViewModel(brand);
        }


        public ModelViewModel(Model model)
        {
            ID = model.ID;
            Name = model.Name;
            Brand = new BrandViewModel(model.Brands);
        }
    }
}