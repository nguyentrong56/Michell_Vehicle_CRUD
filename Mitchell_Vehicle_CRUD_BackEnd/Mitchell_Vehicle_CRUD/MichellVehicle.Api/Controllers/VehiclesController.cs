using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Description;
using Mitchell_Vehicle_CRUD.Data_Access;
using Mitchell_Vehicle_CRUD.Data_Access.Models;

using Mitchell_Vehicle_CRUD.MichellVehicle.Data_Access.DTO;

using Mitchell_Vehicle_CRUD.Services;

namespace Mitchell_Vehicle_CRUD.MichellVehicle.Api.Controllers
{
    
    public class VehiclesController : ApiController
    {

        
        /// <summary>
        /// Support GET method to return all vehicles if no param is given
        /// if params are given, will return list of vehicles match params
        /// </summary>
        /// <param name="filter"> params class object contains 'Make, ' Model', 'Year' </param>
        /// <returns> List of Vehicle </returns>
        [Route("api/vehicles/")]
        [HttpGet]
        [ResponseType(typeof(List<Vehicle>))]
        public IHttpActionResult GetVehicles([FromUri] FilterModel filter)
        {
            using (var dbcontext = new VehicleContext())
            {
                var vehicleService = new VehicleCRUDService(dbcontext);
                try
                {
                    var vehicleList = new List<Vehicle>();
                    // Return all vehicles for null filter
                    if(filter ==  null)
                    {
                        vehicleList = vehicleService.GetAllVehicles().ToList();

                    }
                    // Or return vehicles that match params 
                    else
                    {
                        // Will do waterfall matching from Make --> Model --> Year ---> result
                        vehicleList = vehicleService.GetVehiclesWithParams(filter.Make, filter.Model, filter.Year).ToList();

                    }
                    return Content(HttpStatusCode.OK, vehicleList);
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.InternalServerError, "Oops! Something when wrong on our end");
                }
            }
        }
       
        /// <summary>
        /// Support GET to return vehicle by Id
        /// </summary>
        /// <param name="id"> vehicle Id </param>
        /// <returns> vehicle object</returns>
        [Route("api/vehicles/{id}")]
        [HttpGet]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {
            using (var dbcontext = new VehicleContext())
            {
                var vehicleService = new VehicleCRUDService(dbcontext);
                try
                {
                    var vehicle = vehicleService.GetVehicle(id);
                    if (vehicle != null)
                    {
                        return Content(HttpStatusCode.OK, vehicle);
                    }

                    else
                    {
                        return Content(HttpStatusCode.NotFound, "Vehicle could not be found");
                    }

                   
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.InternalServerError, "Oops! Something when wrong on our end");
                }
            }
               
        }
     
        /// <summary>
        /// Support PUT to update existing vehicle
        /// </summary>
        /// <param name="vehicle"> vehicle object with new information </param>
        /// <returns> updated vehicle object</returns>
        [Route("api/vehicles/")]
        [HttpPut]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult UpdateVehicle(Vehicle vehicle)
        {
            using (var dbcontext = new VehicleContext())
            {
                var vehicleService = new VehicleCRUDService(dbcontext);
                try
                {
                    var v = vehicleService.UpdateVehicle(vehicle);
                    dbcontext.SaveChanges();
                    return Content(HttpStatusCode.OK, v);
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.InternalServerError, "Oops, something is wrong when updating the vehicle");
                }

            }

        }

        
        /// <summary>
        /// Support POST to create new vehicle
        /// </summary>
        /// <param name="vehicle"> new vehicle object</param>
        /// <returns> created vehicle object </returns>
        [Route("api/vehicles/")]
        [HttpPost]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            using (var dbcontext = new VehicleContext())
            {
                var vehicleService = new VehicleCRUDService(dbcontext);
                try
                {
                    var v = vehicleService.ExistingVehicle(vehicle);
                    if (v == true)
                    {
                        return Content(HttpStatusCode.Conflict, "Vehicle already exists");
                    }
                    else
                    {
                        var vehicleHelper = new VehicleHelperService();
                        bool validation = vehicleHelper.VehicleDataValidator(vehicle);

                        if (validation == false)
                        {
                            return Content(HttpStatusCode.Forbidden, vehicleHelper.errorMsg);
                        }
                        else
                        {
                            var newVehicle = vehicleService.CreateVehicle(vehicle);
                            dbcontext.SaveChanges();
                            return Content(HttpStatusCode.OK, newVehicle);
                        }
                    }
                   
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.BadRequest, "Something wrong with internal server ");
                }
            }
        }

        
        /// <summary>
        /// Support DELETE method to delete vehicle using Id
        /// </summary>
        /// <param name="id"> vehicle Id </param>
        /// <returns> deleted vehicle object </returns>
        [Route("api/vehicles/{id}")]
        [HttpDelete]
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            using (var dbcontext = new VehicleContext())
            {
                var vehicleService = new VehicleCRUDService(dbcontext);
                try
                {
                    var vehicle = vehicleService.DeleteVehicle(id);
                    if(vehicle != null)
                    {
                        dbcontext.SaveChanges();
                        return Content(HttpStatusCode.OK, vehicle);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "Vehicle does not exist");
                    }
                    
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.InternalServerError, "Something wrong with internal server");
                }
            }
        }
       
        }
    
}