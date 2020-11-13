using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitchell_Vehicle_CRUD.Services
{
    public interface IVehicleCRUDService
    {
        Vehicle CreateVehicle(Vehicle vehicle);
        Vehicle GetVehicle(int vehicleId);

        IEnumerable<Vehicle> GetVehiclesWithParams(string make, string model, int year);
        Vehicle DeleteVehicle(int vehicleId);
        Vehicle UpdateVehicle(Vehicle vehicle);
        bool ExistingVehicle(Vehicle vehicle);




    }
}
