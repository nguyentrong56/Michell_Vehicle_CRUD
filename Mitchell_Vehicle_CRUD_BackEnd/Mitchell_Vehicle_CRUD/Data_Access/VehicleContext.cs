using Mitchell_Vehicle_CRUD.Data_Access.DataSeeding;
using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mitchell_Vehicle_CRUD.Data_Access
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("VehicleDB")
        {
            Database.SetInitializer(new VehicleDBInitializer());
        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}