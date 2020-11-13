using Mitchell_Vehicle_CRUD.Data_Access;
using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.UI;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Mitchell_Vehicle_CRUD.Services
{
    public class VehicleCRUDService : IVehicleCRUDService
    {
        private readonly VehicleContext _vehicleContext;
        public VehicleCRUDService(VehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            _vehicleContext.Entry(vehicle).State = EntityState.Added;
            return vehicle;
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            _vehicleContext.Entry(vehicle).State = EntityState.Modified;
            return vehicle;
        }

        public Vehicle DeleteVehicle(int vehicleId)
        {
            var vehicle = _vehicleContext.Vehicles.Where(v => v.Id == vehicleId).FirstOrDefault<Vehicle>();
            if (vehicle == null)
            {
                return null;
            }
            else
            {
                _vehicleContext.Entry(vehicle).State = EntityState.Deleted;
                return vehicle;
            }
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            var vehicle = _vehicleContext.Vehicles.Find(vehicleId);
            return vehicle;
        }
   
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var vehicles = _vehicleContext.Vehicles.ToList();
            return vehicles;
        }
        public IEnumerable<Vehicle> GetVehiclesFiltered(int year, string make, string model)
        {
            var v1 = _vehicleContext.Vehicles.Where(v => ((year == 0 || v.Year == year)
                                                &&(make == null || v.Make.Equals(make))
                                                &&(model == null || v.Model.Equals(model)))).ToList();

            return v1;


        }
      
        public bool ExistingVehicle(Vehicle vehicle)
        {
            //var vehicle = _vehicleContext.Vehicles.Find(vehicleId);
            var x = _vehicleContext.Vehicles.Where(v => v.Make.Equals(vehicle.Make) &&
                                                   v.Model.Equals(vehicle.Model) &&
                                                   v.Year == vehicle.Year).FirstOrDefault();
                                                 
            if (x == null)
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