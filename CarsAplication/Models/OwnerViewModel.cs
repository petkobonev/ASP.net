using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsAplication.Models
{
    public class OwnerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public OwnerViewModel(User user)
        {
            ID = user.ID;
            Name = user.Name;
        }
    }
}