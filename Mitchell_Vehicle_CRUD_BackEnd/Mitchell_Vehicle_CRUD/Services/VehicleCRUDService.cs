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
    /// <summary>
    /// Vehicle service class that contains CRUD functions
    /// </summary>
    public class VehicleCRUDService : IVehicleCRUDService
    {
        private readonly VehicleContext _vehicleContext;
        /// <summary>
        /// Constructor that takes in Vehicle database context
        /// </summary>
        /// <param name="vehicleContext"> Database context </param>
        public VehicleCRUDService(VehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        /// <summary>
        /// Function to create new vehicle
        /// </summary>
        /// <param name="vehicle"> new vehicle  </param>
        /// <returns> created vehicle  </returns>
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            _vehicleContext.Entry(vehicle).State = EntityState.Added;
            return vehicle;
        }

        /// <summary>
        /// Function to update existing vehicle
        /// </summary>
        /// <param name="vehicle"> vehicle object which has updated infomation </param>
        /// <returns> updated vehicle </returns>
        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            _vehicleContext.Entry(vehicle).State = EntityState.Modified;
            return vehicle;
        }

        /// <summary>
        /// Function to delete vehicle using Id
        /// </summary>
        /// <param name="vehicleId"> Id of vehicle object</param>
        /// <returns> deleted vehicle </returns>
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

        /// <summary>
        /// Functions to get vehicle by Id
        /// </summary>
        /// <param name="vehicleId"> Id of vehicle </param>
        /// <returns> vehicle object </returns>
        public Vehicle GetVehicle(int vehicleId)
        {
            var vehicle = _vehicleContext.Vehicles.Find(vehicleId);
            return vehicle;
        }

        /// <summary>
        /// Function to return all vehicles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var vehicles = _vehicleContext.Vehicles.ToList();
            return vehicles;
        }

        /// <summary>
        /// Function to get all vehicles if params are empty
        /// Or search for vehicles when using params 
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <returns> List of vehicles as intersection of results of matching each param seperately </returns>
        public IEnumerable<Vehicle> GetVehiclesWithParams(string make, string model, int year)
        {
            var v1 = _vehicleContext.Vehicles.Where(v => ((year == 0 || v.Year == year)
                                                &&(make == null || v.Make.Equals(make))
                                                &&(model == null || v.Model.Equals(model)))).ToList();
            return v1;


        }
      
        /// <summary>
        /// Check if the vehicle already exists
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns> true if vehicle exists </returns>
        public bool ExistingVehicle(Vehicle vehicle)
        {
            //Match all properties with the input vehicle
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