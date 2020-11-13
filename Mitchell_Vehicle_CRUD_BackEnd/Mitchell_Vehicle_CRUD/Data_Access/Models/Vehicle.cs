using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mitchell_Vehicle_CRUD.Data_Access.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]       
        public int Year { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { set; get; }



    }
}