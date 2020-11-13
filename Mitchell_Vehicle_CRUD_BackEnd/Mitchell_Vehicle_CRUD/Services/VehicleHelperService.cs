using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mitchell_Vehicle_CRUD.Services
{
    public class VehicleHelperService
    {
        public string errorMsg { get; set; }
        public bool VehicleDataValidator(Vehicle vehicle)
        {
            DataValidation pv = new DataValidation();
            bool isNull = pv.IsNonEmpty(vehicle, "Make", "Model");
            if (isNull == false)
            {
                errorMsg += "Vehicle Make or Model is missing ";
            }

            bool isInRange = pv.IsInRange(1950, 2050, vehicle, "Year");
            if (isInRange == false)
            {
                errorMsg += "Vehicle year is out of range ";
            }

            if(isNull == false || isInRange == false)
            {
                return false;
            }

            else
            {
                return true;
            }


        }
    }
}