using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mitchell_Vehicle_CRUD.Data_Access;
using Mitchell_Vehicle_CRUD.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mitchell_Vehicle_CRUD.Services.Test
{
    [TestClass]
    public class VehicleCRUDServiceTest
    {
        [TestMethod]
        public void CreateVehicle_ShouldReturnNotNull()
        {

            //Arrange
            VehicleContext context = new VehicleContext();
            VehicleCRUDService vs = new VehicleCRUDService(context);
                Vehicle vehicle = null;
            

                //Act

                vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "Toyota",
                    Model = "Prius",
                    Year = 2019
                });

                context.SaveChanges();


                //Assert
                Assert.IsNotNull(vehicle);
            


        }

        [TestMethod]
        public void UpdateVehicleMake_ShouldReturnNewVehicleMake()
        {
            using (var context = new VehicleContext())
            {
                //Arrange
                VehicleCRUDService vs = new VehicleCRUDService(context);
                var newMake = "Honda";
                
                var vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "Audi",
                    Model = "Etron",
                    Year = 2020
                });
                context.SaveChanges();

                //Act
                var stored = context.Vehicles.Where(v => v.Id == vehicle.Id).FirstOrDefault();
                stored.Make = newMake;
                //stored.Model = newModel;
                //stored.Year = newYear;
                var updated = vs.UpdateVehicle(stored);
                 
                //Assert
                Assert.AreEqual(newMake, updated.Make);
            }
        }

        [TestMethod]
        public void UpdateVehicleMake_ShouldReturnNewVehicleModel()
        {
            using (var context = new VehicleContext())
            {
                //Arrange
                VehicleCRUDService vs = new VehicleCRUDService(context);
               
                var newModel = "Odysse";
                //var newYear = 2019;
                var vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "Audi",
                    Model = "Etron",
                    Year = 2020
                });
                context.SaveChanges();

                //Act
                var stored = context.Vehicles.Where(v => v.Id == vehicle.Id).FirstOrDefault();
                stored.Model = newModel;
                //stored.Model = newModel;
                //stored.Year = newYear;
                var updated = vs.UpdateVehicle(stored);

                //Assert
                Assert.AreEqual(newModel, updated.Model);
            }
        }

        [TestMethod]
        public void UpdateVehicleMake_ShouldReturnNewVehicleYear()
        {
            using (var context = new VehicleContext())
            {
                //Arrange
                VehicleCRUDService vs = new VehicleCRUDService(context);

                var newYear = 2019;
                var vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "Audi",
                    Model = "Etron",
                    Year = 2020
                });
                context.SaveChanges();

                //Act
                var stored = context.Vehicles.Where(v => v.Id == vehicle.Id).FirstOrDefault();
                stored.Year = newYear;
                var updated = vs.UpdateVehicle(stored);

                //Assert
                Assert.AreEqual(newYear, updated.Year);
            }
        }

        [TestMethod]
        public void DeleteVehicle_ShouldReturnNullWhenFindVehicle()
        {
            using (var context = new VehicleContext())
            {
                //Arrange
                VehicleCRUDService vs = new VehicleCRUDService(context);

                var vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "BMW",
                    Model = "X7",
                    Year = 1999
                });

                context.SaveChanges();

                //Act
                var delete = vs.DeleteVehicle(vehicle.Id);
                context.SaveChanges();
                var found = context.Vehicles.Where(v => v.Id == delete.Id).FirstOrDefault();

                //Assert
                Assert.IsNull(found);
            }
        }

        [TestMethod]
        public void GetAllVehicle_ShouldReturnListOfVehicle()
        {
            //Arrange
            using (var context = new VehicleContext())
            {
                VehicleCRUDService vs = new VehicleCRUDService(context);

                var vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "BMW",
                    Model = "X7",
                    Year = 1999
                });

                var vehicle2 = vs.CreateVehicle(new Vehicle
                {
                    Make = "Adui",
                    Model = "A3",
                    Year = 2020
                });

                var vehicle3 = vs.CreateVehicle(new Vehicle
                {
                    Make = "Merc",
                    Model = "E",
                    Year = 2018
                });


                //Act
                var list = vs.GetAllVehicles();

                //Assert
                Assert.IsNotNull(list);
            }
        }

            [TestMethod]
            public void GetVehicleWithParams_ShouldReturnCorrectVehicle()
            {
            using (var context = new VehicleContext())
            {
                //Arrange
                VehicleCRUDService vs = new VehicleCRUDService(context);

                var vehicle = vs.CreateVehicle(new Vehicle
                {
                    Make = "Kia",
                    Model = "Morning",
                    Year = 2019
                });

                context.SaveChanges();

                //Act
                var found = vs.GetVehiclesWithParams("Kia", "Morning", 2019).FirstOrDefault();


                //Assert
                bool check = false;
                if (found.Make.Equals("Kia") && found.Model.Equals("Morning") && found.Year == 2019)
                {
                    check = true;
                }
                Assert.IsTrue(check);
              }
            }
        }

    }
