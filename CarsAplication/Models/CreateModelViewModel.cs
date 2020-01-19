using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class CreateModelViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Brand { get; set; }
        
        public CreateModelViewModel() { }
    }
}