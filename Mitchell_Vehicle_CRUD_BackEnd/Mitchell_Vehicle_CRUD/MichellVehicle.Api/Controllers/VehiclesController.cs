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
                    if(filter ==  null)
                    {
                        vehicleList = vehicleService.GetAllVehicles().ToList();

                    }

                    else
                    {
                        vehicleList = vehicleService.GetVehiclesFiltered(filter.Year, filter.Make, filter.Model).ToList();

                    }
                    return Content(HttpStatusCode.OK, vehicleList);
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.InternalServerError, "Oops! Something when wrong on our end");
                }
            }
        }



       
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
                    return Content(HttpStatusCode.OK, vehicle);
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.NotFound, "Vehicle could not be found");
                }
            }
          
           
        }

        
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