using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mitchell_Vehicle_CRUD.MichellVehicle.Data_Access.DTO
{
    public class FilterModel
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}