using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mitchell_Vehicle_CRUD.Data_Access.DataSeeding
{
    public class VehicleDBInitializer : DropCreateDatabaseAlways<VehicleContext>
    {
        protected override void Seed (VehicleContext context)
        {
            IList<Vehicle> defaultVehicles = new List<Vehicle>();
            defaultVehicles.Add(new Vehicle() { Make = "Honda", Model = "Civic", Year = 2000 });
            defaultVehicles.Add(new Vehicle() { Make = "Toyota", Model = "Camry", Year = 2010 });
            defaultVehicles.Add(new Vehicle() { Make = "Audi", Model = "A6", Year = 2005 });
            defaultVehicles.Add(new Vehicle() { Make = "BMW", Model = "X6", Year = 2019 });
            defaultVehicles.Add(new Vehicle() { Make = "Posche", Model = "Macan", Year = 2018 });
          

            context.Vehicles.AddRange(defaultVehicles);
            base.Seed(context);

        }
    }
}