using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class CreateCarViewModel
    {
        [Required]
        public int Owner { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public int Model { get; set; }

        public CreateCarViewModel() { }



    }
}