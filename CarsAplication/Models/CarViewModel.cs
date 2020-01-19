using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class CarViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public string Color { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        [Required]
        public ModelViewModel Model { get; set; }
        public OwnerViewModel Owner { get; set; }

        public CarViewModel() { }
        public CarViewModel(int id, int horsePower, string color, DateTime year, Model model, OwnerViewModel owner) {
            ID = id;
            HorsePower = horsePower;
            Year = year;
            Color = color;
            Model = new ModelViewModel(model);
            Owner = owner;
        }

    }
}