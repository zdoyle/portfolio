using GuildCars.Data;
using GuildCars.Data.ADO.AdminRepositories;
using GuildCars.Data.ADO.CustomerRepositories;
using GuildCars.Data.ADO.SalesRepositories;
using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.AdminRepositories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables.AdminTables;
using GuildCars.Models.Tables.CustomerTables;
using GuildCars.Models.Tables.SalesTables;
using GuildCars.Models.Tables.VehicleTables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStylesRepositoryADO();

            var bodyStyles = repo.GetAll().ToList();

            Assert.AreEqual(4, bodyStyles.Count);

            Assert.AreEqual(1, bodyStyles[0].BodyStyleId);
            Assert.AreEqual("Car", bodyStyles[0].Name);
        }

        [Test]
        public void CanLoadCarMakes()
        {
            var repo = new CarMakesRepositoryADO();

            var carMakes = repo.GetAll().ToList();

            Assert.AreEqual(62, carMakes.Count);

            Assert.AreEqual(1, carMakes[0].MakeId);
            Assert.AreEqual("Acura", carMakes[0].Name);
        }

        [Test]
        public void CanLoadCarModels()
        {
            var repo = new CarModelsRepositoryADO();

            var carModels = repo.GetAll().ToList();

            Assert.AreEqual(688, carModels.Count);

            Assert.AreEqual(252, carModels[0].ModelId);
            Assert.AreEqual(1, carModels[0].MakeId);
            Assert.AreEqual("CL", carModels[0].Name);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = new ColorsRepositoryADO();

            var colors = repo.GetAll().ToList();

            Assert.AreEqual(8, colors.Count);

            Assert.AreEqual(1, colors[0].ColorId);
            Assert.AreEqual("Black", colors[0].Name);
            Assert.AreEqual("#000", colors[0].ColorCode);
        }

        [Test]
        public void CanLoadDepartments()
        {
            var repo = new DepartmentsRepositoryADO();

            var departments = repo.GetAll().ToList();

            Assert.AreEqual(2, departments.Count);

            Assert.AreEqual(1, departments[0].DepartmentId);
            Assert.AreEqual("Admin", departments[0].Name);
        }

        [Test]
        public void CanLoadInteriorColors()
        {
            var repo = new InteriorColorsRepositoryADO();

            var interiorColors = repo.GetAll().ToList();

            Assert.AreEqual(4, interiorColors.Count);

            Assert.AreEqual(1, interiorColors[0].InteriorColorId);
            Assert.AreEqual("Black", interiorColors[0].Name);
            Assert.AreEqual("#000", interiorColors[0].ColorCode);
        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypesRepositoryADO();

            var puchaseTypes = repo.GetAll().ToList();

            Assert.AreEqual(3, puchaseTypes.Count);

            Assert.AreEqual(1, puchaseTypes[0].PurchaseTypeId);
            Assert.AreEqual("Bank Finance", puchaseTypes[0].Name);
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();

            var states = repo.GetAll().ToList();

            Assert.AreEqual(52, states.Count);

            Assert.AreEqual(1, states[0].StateId);
            Assert.AreEqual("AL", states[0].Abbreviation);
            Assert.AreEqual("Alabama", states[0].Name);
        }

        [Test]
        public void CanLoadTransmissionTypes()
        {
            var repo = new TransmissionTypesRepositoryADO();

            var transmissionTypes = repo.GetAll().ToList();

            Assert.AreEqual(2, transmissionTypes.Count);

            Assert.AreEqual(1, transmissionTypes[0].TransmissionTypeId);
            Assert.AreEqual("Automatic", transmissionTypes[0].Name);
        }

        [Test]
        public void CanLoadVehicleTypes()
        {
            var repo = new VehicleTypesRepositoryADO();

            var vehicleTypes = repo.GetAll().ToList();

            Assert.AreEqual(2, vehicleTypes.Count);

            Assert.AreEqual(1, vehicleTypes[0].VehicleTypeId);
            Assert.AreEqual("New", vehicleTypes[0].Name);
        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetAll().ToList();

            Assert.AreEqual(3, specials.Count);

            Assert.AreEqual(1, specials[0].SpecialId);
            Assert.AreEqual("Columbus Day Blowout!", specials[0].Title);
            Assert.AreEqual("In October of 1942, Christopher Columbus and his expedition reached land somewhere in the Bahamas that he called San Salvador. While he wasn't even close to being the first person to set foot on the Americas, or even the first European to do so, we still remember that monumental day every year in October. Columbus Day may not be the biggest and most celebrated holiday in the country, but it is certainly one of the best holidays to find a great deal on a new car.", specials[0].Description);
        }

        [Test]
        public void CanLoadEmployees()
        {
            var repo = new EmployeesRepositoryADO();

            var employees = repo.GetAll().ToList();

            Assert.AreEqual(4, employees.Count);

            Assert.AreEqual(2, employees[0].EmployeeId);
            Assert.AreEqual("Steve", employees[0].FirstName);
            Assert.AreEqual("Clark", employees[0].LastName);
            Assert.AreEqual(2, employees[0].DepartmentId);
        }

        [Test]
        public void CanLoadAddresses()
        {
            var repo = new AddressesRepositoryADO();

            var addresses = repo.GetAll().ToList();

            Assert.AreEqual(3, addresses.Count);

            Assert.AreEqual(1, addresses[0].AddressId);
            Assert.AreEqual("7729 Rochelle Rd.", addresses[0].StreetAddress1);
            Assert.IsNull(addresses[0].StreetAddress2);
            Assert.AreEqual("Louisville", addresses[0].City);
            Assert.AreEqual(18, addresses[0].StateId);
            Assert.AreEqual(40228, addresses[0].ZipCode);
        }

        [Test]
        public void CanLoadCustomers()
        {
            var repo = new CustomersRepositoryADO();

            var customers = repo.GetAll().ToList();

            Assert.AreEqual(4, customers.Count);

            Assert.AreEqual(2, customers[0].CustomerId);
            Assert.AreEqual("Lacey", customers[0].FirstName);
            Assert.AreEqual("Holman", customers[0].LastName);
            Assert.AreEqual("laceyedoyle@gmail.com", customers[0].Email);
            Assert.AreEqual("5025720606", customers[0].Phone);
            Assert.AreEqual(2, customers[0].AddressId);
        }

        [Test]
        public void CanLoadContacts()
        {
            var repo = new ContactsRepositoryADO();

            var contacts = repo.GetAll().ToList();

            Assert.AreEqual(3, contacts.Count);

            Assert.AreEqual(1, contacts[0].ContactId);
            Assert.AreEqual(1, contacts[0].CustomerId);
            Assert.AreEqual("Can someone please call me?  I don't know where I put my keys to my new car that I just bought from y'all.", contacts[0].Message);
            Assert.That(contacts[0].ContactDate, Is.EqualTo(DateTime.Now).Within(2).Seconds);
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAll().ToList();

            Assert.AreEqual(6, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual("11111111111111111", vehicles[0].VIN);
            Assert.AreEqual(2018, vehicles[0].ModelYear);
            Assert.AreEqual(56, vehicles[0].ModelId);
            Assert.AreEqual(236, vehicles[0].Mileage);
            Assert.AreEqual(2, vehicles[0].TransmissionTypeId);
            Assert.AreEqual(1, vehicles[0].BodyStyleId);
            Assert.AreEqual(5, vehicles[0].ColorId);
            Assert.AreEqual(1, vehicles[0].InteriorColorId);
            Assert.AreEqual(1, vehicles[0].VehicleTypeId);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicles[0].Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicles[0].ImageFileName);
            Assert.AreEqual(92125M, vehicles[0].MSRP);
            Assert.AreEqual(90000M, vehicles[0].SalePrice);
            Assert.AreEqual(1, vehicles[0].EmployeeId);
            Assert.That(vehicles[0].DateAdded, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.IsTrue(vehicles[0].IsFeatured);
            Assert.IsFalse(vehicles[0].IsSold);
        }

        [Test]
        public void CanLoadPurchases()
        {
            var repo = new PurchasesRepositoryADO();

            var purchases = repo.GetAll().ToList();

            Assert.AreEqual(3, purchases.Count);

            Assert.AreEqual(1, purchases[0].PurchaseId);
            Assert.AreEqual(1, purchases[0].CustomerId);
            Assert.AreEqual(4, purchases[0].VehicleId);
            Assert.That(purchases[0].PurchaseDate, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.AreEqual(7200M, purchases[0].PurchasePrice);
            Assert.AreEqual(3, purchases[0].PurchaseTypeId);
            Assert.AreEqual(3, purchases[0].EmployeeId);
        }

        [Test]
        public void CanLoadPurchaseById()
        {
            var repo = new PurchasesRepositoryADO();

            var purchase = repo.GetById(1);

            Assert.IsNotNull(purchase);

            Assert.AreEqual(1, purchase.PurchaseId);
            Assert.AreEqual(1, purchase.CustomerId);
            Assert.AreEqual(4, purchase.VehicleId);
            Assert.That(purchase.PurchaseDate, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.AreEqual(7200M, purchase.PurchasePrice);
            Assert.AreEqual(3, purchase.PurchaseTypeId);
            Assert.AreEqual(3, purchase.EmployeeId);
        }

        [Test]
        public void NotFoundPurchaseReturnsNull()
        {
            var repo = new PurchasesRepositoryADO();

            var purchase = repo.GetById(334);

            Assert.IsNull(purchase);
        }

        [Test]
        public void CanLoadVehicleById()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(2);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(2, vehicle.VehicleId);
            Assert.AreEqual("11111111111111111", vehicle.VIN);
            Assert.AreEqual(2018, vehicle.ModelYear);
            Assert.AreEqual(56, vehicle.ModelId);
            Assert.AreEqual(236, vehicle.Mileage);
            Assert.AreEqual(2, vehicle.TransmissionTypeId);
            Assert.AreEqual(1, vehicle.BodyStyleId);
            Assert.AreEqual(5, vehicle.ColorId);
            Assert.AreEqual(1, vehicle.InteriorColorId);
            Assert.AreEqual(1, vehicle.VehicleTypeId);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicle.Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicle.ImageFileName);
            Assert.AreEqual(92125M, vehicle.MSRP);
            Assert.AreEqual(90000M, vehicle.SalePrice);
            Assert.AreEqual(1, vehicle.EmployeeId);
            Assert.That(vehicle.DateAdded, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.IsTrue(vehicle.IsFeatured);
            Assert.IsFalse(vehicle.IsSold);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(334);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanLoadContactById()
        {
            var repo = new ContactsRepositoryADO();

            var contact = repo.GetById(1);

            Assert.IsNotNull(contact);

            Assert.AreEqual(1, contact.ContactId);
            Assert.AreEqual(1, contact.CustomerId);
            Assert.AreEqual("Can someone please call me?  I don't know where I put my keys to my new car that I just bought from y'all.", contact.Message);
            Assert.That(contact.ContactDate, Is.EqualTo(DateTime.Now).Within(2).Seconds);
        }

        [Test]
        public void NotFoundContactReturnsNull()
        {
            var repo = new ContactsRepositoryADO();

            var contact = repo.GetById(334);

            Assert.IsNull(contact);
        }

        [Test]
        public void CanLoadCustomerById()
        {
            var repo = new CustomersRepositoryADO();

            var customer = repo.GetById(2);

            Assert.IsNotNull(customer);

            Assert.AreEqual(2, customer.CustomerId);
            Assert.AreEqual("Lacey", customer.FirstName);
            Assert.AreEqual("Holman", customer.LastName);
            Assert.AreEqual("laceyedoyle@gmail.com", customer.Email);
            Assert.AreEqual("5025720606", customer.Phone);
            Assert.AreEqual(2, customer.AddressId);
        }

        [Test]
        public void NotFoundCustomerReturnsNull()
        {
            var repo = new CustomersRepositoryADO();

            var customer = repo.GetById(334);

            Assert.IsNull(customer);
        }

        [Test]
        public void CanLoadAddressById()
        {
            var repo = new AddressesRepositoryADO();

            var address = repo.GetById(1);

            Assert.IsNotNull(address);

            Assert.AreEqual(1, address.AddressId);
            Assert.AreEqual("7729 Rochelle Rd.", address.StreetAddress1);
            Assert.IsNull(address.StreetAddress2);
            Assert.AreEqual("Louisville", address.City);
            Assert.AreEqual(18, address.StateId);
            Assert.AreEqual(40228, address.ZipCode);
        }

        [Test]
        public void NotFoundAddressReturnsNull()
        {
            var repo = new AddressesRepositoryADO();

            var address = repo.GetById(334);

            Assert.IsNull(address);
        }

        [Test]
        public void CanLoadEmployeeById()
        {
            var repo = new EmployeesRepositoryADO();

            var employee = repo.GetById(2);

            Assert.IsNotNull(employee);

            Assert.AreEqual(2, employee.EmployeeId);
            Assert.AreEqual("Steve", employee.FirstName);
            Assert.AreEqual("Clark", employee.LastName);
            Assert.AreEqual(2, employee.DepartmentId);
        }

        [Test]
        public void NotFoundEmployeeReturnsNull()
        {
            var repo = new EmployeesRepositoryADO();

            var employee = repo.GetById(334);

            Assert.IsNull(employee);
        }

        [Test]
        public void CanLoadSpecialsById()
        {
            var repo = new SpecialsRepositoryADO();

            var special = repo.GetById(1);

            Assert.IsNotNull(special);

            Assert.AreEqual(1, special.SpecialId);
            Assert.AreEqual("Columbus Day Blowout!", special.Title);
            Assert.AreEqual("In October of 1942, Christopher Columbus and his expedition reached land somewhere in the Bahamas that he called San Salvador. While he wasn't even close to being the first person to set foot on the Americas, or even the first European to do so, we still remember that monumental day every year in October. Columbus Day may not be the biggest and most celebrated holiday in the country, but it is certainly one of the best holidays to find a great deal on a new car.", special.Description);
        }

        [Test]
        public void NotFoundSpecialReturnsNull()
        {
            var repo = new SpecialsRepositoryADO();

            var special = repo.GetById(334);

            Assert.IsNull(special);
        }

        [Test]
        public void CanLoadVehicleTypeById()
        {
            var repo = new VehicleTypesRepositoryADO();

            var vehicleType = repo.GetById(1);

            Assert.IsNotNull(vehicleType);

            Assert.AreEqual(1, vehicleType.VehicleTypeId);
            Assert.AreEqual("New", vehicleType.Name);
        }

        [Test]
        public void NotFoundVehicleTypeReturnsNull()
        {
            var repo = new VehicleTypesRepositoryADO();

            var vehicleType = repo.GetById(52);

            Assert.IsNull(vehicleType);
        }

        [Test]
        public void CanLoadTransmissionTypeById()
        {
            var repo = new TransmissionTypesRepositoryADO();

            var transmissionType = repo.GetById(1);

            Assert.IsNotNull(transmissionType);

            Assert.AreEqual(1, transmissionType.TransmissionTypeId);
            Assert.AreEqual("Automatic", transmissionType.Name);
        }

        [Test]
        public void NotFoundTransmissionTypeReturnsNull()
        {
            var repo = new TransmissionTypesRepositoryADO();

            var transmissionType = repo.GetById(52);

            Assert.IsNull(transmissionType);
        }

        [Test]
        public void CanLoadStateById()
        {
            var repo = new StatesRepositoryADO();

            var state = repo.GetById(1);

            Assert.IsNotNull(state);

            Assert.AreEqual(1, state.StateId);
            Assert.AreEqual("AL", state.Abbreviation);
            Assert.AreEqual("Alabama", state.Name);
        }

        [Test]
        public void NotFoundStateReturnsNull()
        {
            var repo = new StatesRepositoryADO();

            var state = repo.GetById(98);

            Assert.IsNull(state);
        }

        [Test]
        public void CanLoadPurchaseTypeById()
        {
            var repo = new PurchaseTypesRepositoryADO();

            var purchaseType = repo.GetById(1);

            Assert.IsNotNull(purchaseType);

            Assert.AreEqual(1, purchaseType.PurchaseTypeId);
            Assert.AreEqual("Bank Finance", purchaseType.Name);
        }

        [Test]
        public void NotFoundPurchaseTypeReturnsNull()
        {
            var repo = new PurchaseTypesRepositoryADO();

            var purchaseType = repo.GetById(98);

            Assert.IsNull(purchaseType);
        }

        [Test]
        public void CanLoadInteriorColorById()
        {
            var repo = new InteriorColorsRepositoryADO();

            var interiorColor = repo.GetById(1);

            Assert.IsNotNull(interiorColor);

            Assert.AreEqual(1, interiorColor.InteriorColorId);
            Assert.AreEqual("Black", interiorColor.Name);
            Assert.AreEqual("#000", interiorColor.ColorCode);
        }

        [Test]
        public void NotFoundInteriorColorReturnsNull()
        {
            var repo = new InteriorColorsRepositoryADO();

            var interiorColor = repo.GetById(98);

            Assert.IsNull(interiorColor);
        }

        [Test]
        public void CanLoadBodyStyleById()
        {
            var repo = new BodyStylesRepositoryADO();

            var bodyStyle = repo.GetById(1);

            Assert.IsNotNull(bodyStyle);

            Assert.AreEqual(1, bodyStyle.BodyStyleId);
            Assert.AreEqual("Car", bodyStyle.Name);
        }

        [Test]
        public void NotFoundBodyStyleReturnsNull()
        {
            var repo = new BodyStylesRepositoryADO();

            var bodyStyle = repo.GetById(98);

            Assert.IsNull(bodyStyle);
        }

        [Test]
        public void CanLoadCarMakeById()
        {
            var repo = new CarMakesRepositoryADO();

            var carMake = repo.GetById(1);

            Assert.IsNotNull(carMake);

            Assert.AreEqual(1, carMake.MakeId);
            Assert.AreEqual("Acura", carMake.Name);
        }

        [Test]
        public void NotFoundCarMakeReturnsNull()
        {
            var repo = new CarMakesRepositoryADO();

            var carMake = repo.GetById(675);

            Assert.IsNull(carMake);
        }

        [Test]
        public void CanLoadCarModelById()
        {
            var repo = new CarModelsRepositoryADO();

            var carModel = repo.GetById(252);

            Assert.IsNotNull(carModel);

            Assert.AreEqual(252, carModel.ModelId);
            Assert.AreEqual(1, carModel.MakeId);
            Assert.AreEqual("CL", carModel.Name);
        }

        [Test]
        public void NotFoundCarModelReturnsNull()
        {
            var repo = new CarModelsRepositoryADO();

            var carModel = repo.GetById(1562);

            Assert.IsNull(carModel);
        }

        [Test]
        public void CanLoadColorById()
        {
            var repo = new ColorsRepositoryADO();

            var color = repo.GetById(1);

            Assert.IsNotNull(color);

            Assert.AreEqual(1, color.ColorId);
            Assert.AreEqual("Black", color.Name);
            Assert.AreEqual("#000", color.ColorCode);
        }

        [Test]
        public void NotFoundColorReturnsNull()
        {
            var repo = new ColorsRepositoryADO();

            var Color = repo.GetById(98);

            Assert.IsNull(Color);
        }

        [Test]
        public void CanLoadDepartmentById()
        {
            var repo = new DepartmentsRepositoryADO();

            var department = repo.GetById(1);

            Assert.IsNotNull(department);

            Assert.AreEqual(1, department.DepartmentId);
            Assert.AreEqual("Admin", department.Name);
        }

        [Test]
        public void NotFoundDepartmentReturnsNull()
        {
            var repo = new DepartmentsRepositoryADO();

            var department = repo.GetById(98);

            Assert.IsNull(department);
        }

        [Test]
        public void CanLoadVehicleDetailsByIsSold()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetDetailsAllByIsSold(false).ToList();

            Assert.AreEqual(3, vehicles.Count);

            Assert.AreEqual(2, vehicles[1].VehicleId);
            Assert.AreEqual("11111111111111111", vehicles[1].VIN);
            Assert.AreEqual(2018, vehicles[1].ModelYear);
            Assert.AreEqual("Dodge", vehicles[1].Make);
            Assert.AreEqual("Viper", vehicles[1].Model);
            Assert.AreEqual("New", vehicles[1].VehicleType);
            Assert.AreEqual(236, vehicles[1].Mileage);
            Assert.AreEqual("Manual", vehicles[1].TransmissionType);
            Assert.AreEqual("Car", vehicles[1].BodyStyle);
            Assert.AreEqual("Red", vehicles[1].Color);
            Assert.AreEqual("#ea1c28", vehicles[1].ColorCode);
            Assert.AreEqual("Black", vehicles[1].InteriorColor);
            Assert.AreEqual("#000", vehicles[1].InteriorColorCode);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicles[1].Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicles[1].ImageFileName);
            Assert.AreEqual(92125M, vehicles[1].MSRP);
            Assert.AreEqual(90000M, vehicles[1].SalePrice);
        }

        [Test]
        public void CanLoadVehicleDetailsByVehicleTypeIdNoSearch()
        {
            var repo = new VehiclesRepositoryADO();
            

            var vehicles = repo.GetDetailsAllByVehicleTypeId(1).ToList();

            Assert.AreEqual(1, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual("11111111111111111", vehicles[0].VIN);
            Assert.AreEqual(2018, vehicles[0].ModelYear);
            Assert.AreEqual("Dodge", vehicles[0].Make);
            Assert.AreEqual("Viper", vehicles[0].Model);
            Assert.AreEqual("New", vehicles[0].VehicleType);
            Assert.AreEqual(236, vehicles[0].Mileage);
            Assert.AreEqual("Manual", vehicles[0].TransmissionType);
            Assert.AreEqual("Car", vehicles[0].BodyStyle);
            Assert.AreEqual("Red", vehicles[0].Color);
            Assert.AreEqual("#ea1c28", vehicles[0].ColorCode);
            Assert.AreEqual("Black", vehicles[0].InteriorColor);
            Assert.AreEqual("#000", vehicles[0].InteriorColorCode);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicles[0].Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicles[0].ImageFileName);
            Assert.AreEqual(92125M, vehicles[0].MSRP);
            Assert.AreEqual(90000M, vehicles[0].SalePrice);
        }

        [Test]
        public void CanLoadVehicleDetailsByVehicleTypeIdWithSearchQuery()
        {
            var repo = new VehiclesRepositoryADO();

            var query = new VehicleQuery();

            query.SearchQuery = "vi";

            var vehicles = repo.GetDetailsAllByVehicleTypeId(1, query).ToList();

            Assert.AreEqual(1, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual("11111111111111111", vehicles[0].VIN);
            Assert.AreEqual(2018, vehicles[0].ModelYear);
            Assert.AreEqual("Dodge", vehicles[0].Make);
            Assert.AreEqual("Viper", vehicles[0].Model);
            Assert.AreEqual("New", vehicles[0].VehicleType);
            Assert.AreEqual(236, vehicles[0].Mileage);
            Assert.AreEqual("Manual", vehicles[0].TransmissionType);
            Assert.AreEqual("Car", vehicles[0].BodyStyle);
            Assert.AreEqual("Red", vehicles[0].Color);
            Assert.AreEqual("#ea1c28", vehicles[0].ColorCode);
            Assert.AreEqual("Black", vehicles[0].InteriorColor);
            Assert.AreEqual("#000", vehicles[0].InteriorColorCode);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicles[0].Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicles[0].ImageFileName);
            Assert.AreEqual(92125M, vehicles[0].MSRP);
            Assert.AreEqual(90000M, vehicles[0].SalePrice);
        }

        [Test]
        public void CanLoadVehicleDetailsByVehicleTypeIdWithDropdowns()
        {
            var repo = new VehiclesRepositoryADO();

            var query = new VehicleQuery();

            query.MinPrice = 7000M;
            query.MaxPrice = 9000M;
            query.MinYear = 2004;
            query.MaxYear = 2010;


            var vehicles = repo.GetDetailsAllByVehicleTypeId(2, query).ToList();

            Assert.AreEqual(1, vehicles.Count);

            Assert.AreEqual(6, vehicles[0].VehicleId);
            Assert.AreEqual("55555555555555555", vehicles[0].VIN);
            Assert.AreEqual(2008, vehicles[0].ModelYear);
            Assert.AreEqual("Mazda", vehicles[0].Make);
            Assert.AreEqual("Mazda3", vehicles[0].Model);
            Assert.AreEqual("Used", vehicles[0].VehicleType);
            Assert.AreEqual(132000, vehicles[0].Mileage);
            Assert.AreEqual("Automatic", vehicles[0].TransmissionType);
            Assert.AreEqual("Car", vehicles[0].BodyStyle);
            Assert.AreEqual("Black", vehicles[0].Color);
            Assert.AreEqual("#000", vehicles[0].ColorCode);
            Assert.AreEqual("Black", vehicles[0].InteriorColor);
            Assert.AreEqual("#000", vehicles[0].InteriorColorCode);
            Assert.AreEqual("Nice car. Runs great!", vehicles[0].Description);
            Assert.AreEqual("inventory-x-4.jpg", vehicles[0].ImageFileName);
            Assert.AreEqual(8500M, vehicles[0].MSRP);
            Assert.AreEqual(8000M, vehicles[0].SalePrice);
        }

        [Test]
        public void CanLoadSalesReportAll()
        {
            var repo = new PurchasesRepositoryADO();

            var request = repo.GetAllTotalSales().ToList();

            Assert.AreEqual(2, request.Count);

            Assert.AreEqual(2, request[0].EmployeeId);
            Assert.AreEqual("Steve Clark", request[0].EmployeeName);
            Assert.AreEqual(178300M, request[0].TotalSales);
            Assert.AreEqual(2, request[0].TotalVehicles);
        }

        [Test]
        public void CanLoadVehicleDetails()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetDetailsAll().ToList();

            Assert.AreEqual(3, vehicles.Count);

            Assert.AreEqual(2, vehicles[2].VehicleId);
            Assert.AreEqual("11111111111111111", vehicles[2].VIN);
            Assert.AreEqual(2018, vehicles[2].ModelYear);
            Assert.AreEqual("Dodge", vehicles[2].Make);
            Assert.AreEqual("Viper", vehicles[2].Model);
            Assert.AreEqual("New", vehicles[2].VehicleType);
            Assert.AreEqual(236, vehicles[2].Mileage);
            Assert.AreEqual("Manual", vehicles[2].TransmissionType);
            Assert.AreEqual("Car", vehicles[2].BodyStyle);
            Assert.AreEqual("Red", vehicles[2].Color);
            Assert.AreEqual("#ea1c28", vehicles[2].ColorCode);
            Assert.AreEqual("Black", vehicles[2].InteriorColor);
            Assert.AreEqual("#000", vehicles[2].InteriorColorCode);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicles[2].Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicles[2].ImageFileName);
            Assert.AreEqual(92125M, vehicles[2].MSRP);
            Assert.AreEqual(90000M, vehicles[2].SalePrice);
        }

        [Test]
        public void CanLoadCarModelDetailsAll()
        {
            var repo = new CarModelsRepositoryADO();

            var request = repo.GetDetailsAllInStock().ToList();

            Assert.AreEqual(3, request.Count);

            Assert.AreEqual("Chevrolet", request[0].Make);
            Assert.AreEqual("Blazer", request[0].Model);
            Assert.That(request[0].DateAdded.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.AreEqual("admin@guildcars.com", request[0].Employee);
        }

        [Test]
        public void CanLoadCarMakeDetailsAll()
        {
            var repo = new CarMakesRepositoryADO();

            var request = repo.GetDetailsAllInStock().ToList();

            Assert.AreEqual(3, request.Count);

            Assert.AreEqual("Chevrolet", request[0].Make);
            Assert.That(request[0].DateAdded.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.AreEqual("admin@guildcars.com", request[0].Employee);
        }

        [Test]
        public void CanLoadFeaturedVehicleDetailsAll()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetFeaturedDetailsAll().ToList();

            Assert.AreEqual(3, vehicles.Count);

            Assert.AreEqual(2, vehicles[0].VehicleId);
            Assert.AreEqual(2018, vehicles[0].ModelYear);
            Assert.AreEqual(14, vehicles[0].MakeId);
            Assert.AreEqual("Dodge", vehicles[0].MakeName);
            Assert.AreEqual(56, vehicles[0].ModelId);
            Assert.AreEqual("Viper", vehicles[0].ModelName);
            Assert.AreEqual("inventory-x-2.jpg", vehicles[0].ImageFileName);
            Assert.AreEqual(90000M, vehicles[0].SalePrice);
        }

        [Test]
        public void CanLoadInventoryReportDetails()
        {
            var repo = new VehiclesRepositoryADO();

            var request = repo.GetTotalInventoryDetailsAll().ToList();

            Assert.AreEqual(3, request.Count);

            Assert.AreEqual(2018, request[0].ModelYear);
            Assert.AreEqual(14, request[0].MakeId);
            Assert.AreEqual(56, request[0].ModelId);
            Assert.AreEqual("Dodge", request[0].MakeName);
            Assert.AreEqual("Viper", request[0].ModelName);
            Assert.AreEqual(1, request[0].VehicleTypeId);
            Assert.AreEqual(1, request[0].VehiclesInStock);
            Assert.AreEqual(92125M, request[0].StockValue);
        }

        [Test]
        public void CanAddSpecial()
        {
            Special specialToAdd = new Special();
            var repo = new SpecialsRepositoryADO();

            specialToAdd.Title = "Black Friday Special";
            specialToAdd.Description = "We are even open on Thanksgiving!";

            repo.Insert(specialToAdd);

            var specials = repo.GetAll().ToList();

            Assert.AreEqual(4, specials.Count);

            Assert.AreEqual(4, specials[0].SpecialId);
            Assert.AreEqual("Black Friday Special", specials[0].Title);
            Assert.AreEqual("We are even open on Thanksgiving!", specials[0].Description);
        }

        [Test]
        public void CanAddCustomerWithNewAddress()
        {
            Customer customerToAdd = new Customer();
            Address addressToAdd = new Address();
            var repo = new CustomersRepositoryADO();
            var addressesCount = new AddressesRepositoryADO().GetAll().Count();

            customerToAdd.FirstName = "Zack";
            customerToAdd.LastName = "Morris";
            customerToAdd.Email = "zack@sbtb.com";
            customerToAdd.Phone = "5555555555";
            addressToAdd.StreetAddress1 = "Bayside High School";
            addressToAdd.StreetAddress2 = "123 E. Beach St.";
            addressToAdd.City = "Beverly Hills";
            addressToAdd.StateId = 5;
            addressToAdd.ZipCode = 90210;

            repo.Insert(customerToAdd, addressToAdd);

            var customers = repo.GetAll().ToList();

            Assert.AreEqual(5, customers.Count);

            Assert.AreEqual(5, customers[3].CustomerId);
            Assert.AreEqual("Zack", customers[3].FirstName);
            Assert.AreEqual("Morris", customers[3].LastName);
            Assert.AreEqual("zack@sbtb.com", customers[3].Email);
            Assert.AreEqual("5555555555", customers[3].Phone);
            Assert.AreEqual(4, customers[3].AddressId);

            var newAddressesCount = new AddressesRepositoryADO().GetAll().Count();

            Assert.AreEqual(addressesCount + 1, newAddressesCount);
        }

        [Test]
        public void CanAddCustomerWithExistingAddress()
        {
            Customer customerToAdd = new Customer();
            Address addressToAdd = new Address();
            var repo = new CustomersRepositoryADO();
            var addressesCount = new AddressesRepositoryADO().GetAll().Count();

            customerToAdd.FirstName = "Amanda";
            customerToAdd.LastName = "Buchholz";
            customerToAdd.Email = "amanda.buchholz@oldham.kyschools.us";
            customerToAdd.Phone = "5555555555";
            addressToAdd.StreetAddress1 = "North Oldham High School";
            addressToAdd.StreetAddress2 = "1815 S. Hwy. 1793";
            addressToAdd.City = "Goshen";
            addressToAdd.StateId = 18;
            addressToAdd.ZipCode = 40026;

            repo.Insert(customerToAdd, addressToAdd);

            var customers = repo.GetAll().ToList();

            Assert.AreEqual(5, customers.Count);

            Assert.AreEqual(5, customers[0].CustomerId);
            Assert.AreEqual("Amanda", customers[0].FirstName);
            Assert.AreEqual("Buchholz", customers[0].LastName);
            Assert.AreEqual("amanda.buchholz@oldham.kyschools.us", customers[0].Email);
            Assert.AreEqual("5555555555", customers[0].Phone);
            Assert.AreEqual(3, customers[0].AddressId);

            var newAddressesCount = new AddressesRepositoryADO().GetAll().Count();

            Assert.AreEqual(addressesCount, newAddressesCount);
        }

        [Test]
        public void CanAddCustomerWithNoAddress()
        {
            Customer customerToAdd = new Customer();
            Address addressToAdd = new Address();

            var repo = new CustomersRepositoryADO();
            var addressesCount = new AddressesRepositoryADO().GetAll().Count();

            customerToAdd.FirstName = "Amanda";
            customerToAdd.LastName = "Buchholz";
            customerToAdd.Email = "amanda.buchholz@oldham.kyschools.us";
            customerToAdd.Phone = "5555555555";

            repo.Insert(customerToAdd, addressToAdd);

            var customers = repo.GetAll().ToList();

            Assert.AreEqual(5, customers.Count);

            Assert.AreEqual(5, customers[0].CustomerId);
            Assert.AreEqual("Amanda", customers[0].FirstName);
            Assert.AreEqual("Buchholz", customers[0].LastName);
            Assert.AreEqual("amanda.buchholz@oldham.kyschools.us", customers[0].Email);
            Assert.AreEqual("5555555555", customers[0].Phone);
            Assert.IsNull(customers[0].AddressId);

            var newAddressesCount = new AddressesRepositoryADO().GetAll().Count();

            Assert.AreEqual(addressesCount, newAddressesCount);
        }

        [Test]
        public void CanAddEmployee()
        {
            Employee employeeToAdd = new Employee();
            var repo = new EmployeesRepositoryADO();

            employeeToAdd.FirstName = "Christina";
            employeeToAdd.LastName = "Kuo";
            employeeToAdd.DepartmentId = 1;

            repo.Insert(employeeToAdd);

            var employees = repo.GetAll().ToList();

            Assert.AreEqual(5, employees.Count);

            Assert.AreEqual(5, employees[4].EmployeeId);
            Assert.AreEqual("Christina", employees[4].FirstName);
            Assert.AreEqual("Kuo", employees[4].LastName);
            Assert.AreEqual(1, employees[4].DepartmentId);
        }

        [Test]
        public void CanAddContactFromNewCustomer()
        {
            Customer customerToAdd = new Customer();
            Contact contactToAdd = new Contact();

            var customersCount = new CustomersRepositoryADO().GetAll().Count();

            var repo = new ContactsRepositoryADO();

            customerToAdd.FirstName = "Morgan";
            customerToAdd.LastName = "Fletcher";
            customerToAdd.Email = "morgan@hatfieldmedia.com";
            customerToAdd.Phone = "5555555555";

            contactToAdd.Message = "I HATE YOU GUYS!";

            repo.Insert(customerToAdd, contactToAdd);

            var contacts = repo.GetAll().ToList();

            Assert.AreEqual(4, contacts.Count);

            Assert.AreEqual(4, contacts[3].ContactId);
            Assert.AreEqual(5, contacts[3].CustomerId);
            Assert.That(contacts[3].ContactDate, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.AreEqual("I HATE YOU GUYS!", contacts[3].Message);

            var newCustomersCount = new CustomersRepositoryADO().GetAll().Count();

            Assert.AreEqual(customersCount + 1, newCustomersCount);
        }

        [Test]
        public void CanUpdateCustomerWithTwoNewContactPieces()
        {
            Customer customerToAdd = new Customer();
            Address addressToAdd = new Address();
            var repo = new CustomersRepositoryADO();
            var addressesCount = new AddressesRepositoryADO().GetAll().Count();

            customerToAdd.FirstName = "Zack";
            customerToAdd.LastName = "Morris";
            customerToAdd.Email = "zack@sbtb.com";
            customerToAdd.Phone = "5555555555";
            addressToAdd.StreetAddress1 = "Bayside High School";
            addressToAdd.StreetAddress2 = "123 E. Beach St.";
            addressToAdd.City = "Beverly Hills";
            addressToAdd.StateId = 5;
            addressToAdd.ZipCode = 90210;

            repo.Insert(customerToAdd, addressToAdd);

            customerToAdd.Email = "zack@baysidehigh.edu";
            customerToAdd.Phone = "5027515515";

            repo.Update(customerToAdd);

            var updatedCustomer = repo.GetById(5);

            Assert.AreEqual(5, updatedCustomer.CustomerId);
            Assert.AreEqual("Zack", updatedCustomer.FirstName);
            Assert.AreEqual("Morris", updatedCustomer.LastName);
            Assert.AreEqual("zack@baysidehigh.edu", updatedCustomer.Email);
            Assert.AreEqual("5027515515", updatedCustomer.Phone);
            Assert.AreEqual(4, updatedCustomer.AddressId);
        }

        [Test]
        public void CanUpdateCustomerWithOneNewContactPiece()
        {
            Customer customerToAdd = new Customer();
            Address addressToAdd = new Address();
            var repo = new CustomersRepositoryADO();
            var addressesCount = new AddressesRepositoryADO().GetAll().Count();

            customerToAdd.FirstName = "Zack";
            customerToAdd.LastName = "Morris";
            customerToAdd.Email = "zack@sbtb.com";
            customerToAdd.Phone = "5555555555";
            addressToAdd.StreetAddress1 = "Bayside High School";
            addressToAdd.StreetAddress2 = "123 E. Beach St.";
            addressToAdd.City = "Beverly Hills";
            addressToAdd.StateId = 5;
            addressToAdd.ZipCode = 90210;

            repo.Insert(customerToAdd, addressToAdd);

            customerToAdd.Email = "zack@baysidehigh.edu";

            repo.Update(customerToAdd);

            var updatedCustomer = repo.GetById(5);

            Assert.AreEqual(5, updatedCustomer.CustomerId);
            Assert.AreEqual("Zack", updatedCustomer.FirstName);
            Assert.AreEqual("Morris", updatedCustomer.LastName);
            Assert.AreEqual("zack@baysidehigh.edu", updatedCustomer.Email);
            Assert.AreEqual("5555555555", updatedCustomer.Phone);
            Assert.AreEqual(4, updatedCustomer.AddressId);
        }

        [Test]
        public void CanAddContactFromExistingCustomerWithSameContactInfo()
        {
            Customer customerToAdd = new Customer();
            Contact contactToAdd = new Contact();


            var customersCount = new CustomersRepositoryADO().GetAll().Count();

            var repo = new ContactsRepositoryADO();

            customerToAdd.FirstName = "Ramona";
            customerToAdd.LastName = "Josephine";
            customerToAdd.Email = "romajodoyle@gmail.com";

            contactToAdd.Message = "I'm a baby!";

            repo.Insert(customerToAdd, contactToAdd);

            var contacts = repo.GetAll().ToList();

            Assert.AreEqual(4, contacts.Count);

            Assert.AreEqual(4, contacts[3].ContactId);
            Assert.AreEqual(4, contacts[3].CustomerId);
            Assert.That(contacts[3].ContactDate, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.AreEqual("I'm a baby!", contacts[3].Message);

            var customerRepo = new CustomersRepositoryADO();

            var newCustomersCount = customerRepo.GetAll().Count();

            Assert.AreEqual(customersCount, newCustomersCount);

            var customers = customerRepo.GetAll().ToList();

            Assert.AreEqual(4, customers[2].CustomerId);
            Assert.AreEqual("Ramona", customers[2].FirstName);
            Assert.AreEqual("Josephine", customers[2].LastName);
            Assert.AreEqual("romajodoyle@gmail.com", customers[2].Email);
            Assert.AreEqual("5027515515", customers[2].Phone);
        }

        [Test]
        public void CanAddPurchaseFromNewCustomerNewAddress()
        {
            Customer customerToAdd = new Customer();
            Purchase purchaseToAdd = new Purchase();
            Address addressToAdd = new Address();

            var customersRepo = new CustomersRepositoryADO();
            var purchasesRepo = new PurchasesRepositoryADO();
            var addressesRepo = new AddressesRepositoryADO();

            var customersCount = customersRepo.GetAll().Count();
            var addressesCount = addressesRepo.GetAll().Count();

            customerToAdd.FirstName = "Morgan";
            customerToAdd.LastName = "Fletcher";
            customerToAdd.Email = "morgan@hatfieldmedia.com";
            customerToAdd.Phone = "5555555555";
            addressToAdd.StreetAddress1 = "12450 LAKE STATION PLACE";
            addressToAdd.City = "Louisville";
            addressToAdd.StateId = 18;
            addressToAdd.ZipCode = 40299;

            purchaseToAdd.VehicleId = 2;
            purchaseToAdd.PurchasePrice = 87500M;
            purchaseToAdd.PurchaseTypeId = 2;
            purchaseToAdd.EmployeeId = 3;

            purchasesRepo.Insert(customerToAdd, purchaseToAdd, addressToAdd);

            var purchases = purchasesRepo.GetAll().ToList();

            Assert.AreEqual(4, purchases.Count);

            Assert.AreEqual(4, purchases[3].PurchaseId);
            Assert.AreEqual(5, purchases[3].CustomerId);
            Assert.That(purchases[3].PurchaseDate.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.AreEqual(87500M, purchases[3].PurchasePrice);
            Assert.AreEqual(2, purchases[3].PurchaseTypeId);
            Assert.AreEqual(3, purchases[3].EmployeeId);

            var newCustomersCount = customersRepo.GetAll().Count();

            Assert.AreEqual(customersCount + 1, newCustomersCount);

            var newAddressesCount = addressesRepo.GetAll().Count();

            Assert.AreEqual(addressesCount + 1, newAddressesCount);
        }

        [Test]
        public void CanAddPurchaseFromNewCustomerExistingAddress()
        {
            Customer customerToAdd = new Customer();
            Purchase purchaseToAdd = new Purchase();
            Address addressToAdd = new Address();

            var customersRepo = new CustomersRepositoryADO();
            var purchasesRepo = new PurchasesRepositoryADO();
            var addressesRepo = new AddressesRepositoryADO();

            var customersCount = customersRepo.GetAll().Count();
            var addressesCount = addressesRepo.GetAll().Count();

            customerToAdd.FirstName = "Morgan";
            customerToAdd.LastName = "Fletcher";
            customerToAdd.Email = "morgan@hatfieldmedia.com";
            customerToAdd.Phone = "5555555555";
            addressToAdd.StreetAddress1 = "6401 Jacob School Rd.";
            addressToAdd.City = "Prospect";
            addressToAdd.StateId = 18;
            addressToAdd.ZipCode = 40059;

            purchaseToAdd.VehicleId = 2;
            purchaseToAdd.PurchasePrice = 87500M;
            purchaseToAdd.PurchaseTypeId = 2;
            purchaseToAdd.EmployeeId = 3;

            purchasesRepo.Insert(customerToAdd, purchaseToAdd, addressToAdd);

            var purchases = purchasesRepo.GetAll().ToList();

            Assert.AreEqual(4, purchases.Count);

            Assert.AreEqual(4, purchases[3].PurchaseId);
            Assert.AreEqual(5, purchases[3].CustomerId);
            Assert.That(purchases[3].PurchaseDate.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.AreEqual(87500M, purchases[3].PurchasePrice);
            Assert.AreEqual(2, purchases[3].PurchaseTypeId);
            Assert.AreEqual(3, purchases[3].EmployeeId);

            var newCustomersCount = customersRepo.GetAll().Count();

            Assert.AreEqual(customersCount + 1, newCustomersCount);

            var newAddressesCount = addressesRepo.GetAll().Count();

            Assert.AreEqual(addressesCount, newAddressesCount);
        }

        [Test]
        public void CanAddPurchaseFromExistingCustomerSameAddress()
        {
            Customer customerToAdd = new Customer();
            Purchase purchaseToAdd = new Purchase();
            Address addressToAdd = new Address();

            var customersRepo = new CustomersRepositoryADO();
            var purchasesRepo = new PurchasesRepositoryADO();
            var addressesRepo = new AddressesRepositoryADO();

            var customersCount = customersRepo.GetAll().Count();
            var addressesCount = addressesRepo.GetAll().Count();

            customerToAdd.FirstName = "Ramona";
            customerToAdd.LastName = "Josephine";
            customerToAdd.Email = "romajodoyle@gmail.com";
            customerToAdd.Phone = "5027515515";
            addressToAdd.StreetAddress1 = "6401 Jacob School Rd.";
            addressToAdd.City = "Prospect";
            addressToAdd.StateId = 18;
            addressToAdd.ZipCode = 40059;

            purchaseToAdd.VehicleId = 2;
            purchaseToAdd.PurchasePrice = 87500M;
            purchaseToAdd.PurchaseTypeId = 2;
            purchaseToAdd.EmployeeId = 3;

            purchasesRepo.Insert(customerToAdd, purchaseToAdd, addressToAdd);

            var purchases = purchasesRepo.GetAll().ToList();

            Assert.AreEqual(4, purchases.Count);

            Assert.AreEqual(4, purchases[3].PurchaseId);
            Assert.AreEqual(4, purchases[3].CustomerId);
            Assert.That(purchases[3].PurchaseDate.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.AreEqual(87500M, purchases[3].PurchasePrice);
            Assert.AreEqual(2, purchases[3].PurchaseTypeId);
            Assert.AreEqual(3, purchases[3].EmployeeId);

            var newCustomersCount = customersRepo.GetAll().Count();

            Assert.AreEqual(customersCount, newCustomersCount);

            var newAddressesCount = addressesRepo.GetAll().Count();

            Assert.AreEqual(addressesCount, newAddressesCount);
        }

        [Test]
        public void CanAddPurchaseFromExistingCustomerNewAddress()
        {
            Customer customerToAdd = new Customer();
            Purchase purchaseToAdd = new Purchase();
            Address addressToAdd = new Address();

            var customersRepo = new CustomersRepositoryADO();
            var purchasesRepo = new PurchasesRepositoryADO();
            var addressesRepo = new AddressesRepositoryADO();

            var customersCount = customersRepo.GetAll().Count();
            var addressesCount = addressesRepo.GetAll().Count();

            customerToAdd.FirstName = "Ramona";
            customerToAdd.LastName = "Josephine";
            customerToAdd.Email = "romajodoyle@gmail.com";
            addressToAdd.StreetAddress1 = "12450 LAKE STATION PLACE";
            addressToAdd.City = "Louisville";
            addressToAdd.StateId = 18;
            addressToAdd.ZipCode = 40299;

            purchaseToAdd.VehicleId = 2;
            purchaseToAdd.PurchasePrice = 87500M;
            purchaseToAdd.PurchaseTypeId = 2;
            purchaseToAdd.EmployeeId = 3;

            purchasesRepo.Insert(customerToAdd, purchaseToAdd, addressToAdd);

            var purchases = purchasesRepo.GetAll().ToList();

            Assert.AreEqual(4, purchases.Count);

            Assert.AreEqual(4, purchases[3].PurchaseId);
            Assert.AreEqual(4, purchases[3].CustomerId);
            Assert.That(purchases[3].PurchaseDate.ToShortDateString(), Is.EqualTo(DateTime.Now.ToShortDateString()));
            Assert.AreEqual(87500M, purchases[3].PurchasePrice);
            Assert.AreEqual(2, purchases[3].PurchaseTypeId);
            Assert.AreEqual(3, purchases[3].EmployeeId);

            var newCustomersCount = customersRepo.GetAll().Count();

            Assert.AreEqual(customersCount, newCustomersCount);

            var newAddressesCount = addressesRepo.GetAll().Count();

            Assert.AreEqual(addressesCount + 1, newAddressesCount);
        }

        [Test]
        public void CanAddCarMake()
        {
            CarMake carMakeToAdd = new CarMake();

            var repo = new CarMakesRepositoryADO();

            carMakeToAdd.Name = "Zoltan";

            repo.Insert(carMakeToAdd);

            var makes = repo.GetAll().ToList();

            Assert.AreEqual(63, makes.Count);

            Assert.AreEqual(63, makes[62].MakeId);
            Assert.AreEqual("Zoltan", makes[62].Name);
        }

        [Test]
        public void CanAddModelWithExistingMake()
        {
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var makesCount = makeRepo.GetAll().Count();

            carModelToAdd.Name = "Aardvark";
            carMakeToAdd.MakeId = 1;
            carMakeToAdd.Name = "Acura";

            modelRepo.Insert(carModelToAdd, carMakeToAdd);

            var models = modelRepo.GetAll().ToList();

            Assert.AreEqual(689, models.Count);

            Assert.AreEqual(689, models[0].ModelId);
            Assert.AreEqual(1, models[0].MakeId);
            Assert.AreEqual("Aardvark", models[0].Name);

            var newMakesCount = makeRepo.GetAll().Count();

            Assert.AreEqual(makesCount, newMakesCount);
        }

        [Test]
        public void CanAddModelWithNewMake()
        {
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var makesCount = makeRepo.GetAll().Count();

            carModelToAdd.Name = "Party Van";
            carMakeToAdd.Name = "Zoltan";

            modelRepo.Insert(carModelToAdd, carMakeToAdd);

            var models = modelRepo.GetAll().ToList();

            Assert.AreEqual(689, models.Count);

            Assert.AreEqual(689, models[688].ModelId);
            Assert.AreEqual(63, models[688].MakeId);
            Assert.AreEqual("Party Van", models[688].Name);

            var newMakesCount = makeRepo.GetAll().Count();

            Assert.AreEqual(makesCount + 1, newMakesCount);
        }

        [Test]
        public void CanLoadVehicleDetailsById()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetDetailsById(2);

            Assert.AreEqual(2, vehicle.VehicleId);
            Assert.AreEqual("11111111111111111", vehicle.VIN);
            Assert.AreEqual(2018, vehicle.ModelYear);
            Assert.AreEqual("Dodge", vehicle.Make);
            Assert.AreEqual("Viper", vehicle.Model);
            Assert.AreEqual("New", vehicle.VehicleType);
            Assert.AreEqual(236, vehicle.Mileage);
            Assert.AreEqual("Manual", vehicle.TransmissionType);
            Assert.AreEqual("Car", vehicle.BodyStyle);
            Assert.AreEqual("Red", vehicle.Color);
            Assert.AreEqual("#ea1c28", vehicle.ColorCode);
            Assert.AreEqual("Black", vehicle.InteriorColor);
            Assert.AreEqual("#000", vehicle.InteriorColorCode);
            Assert.AreEqual("When you see the Dodge Viper SRT® your eyes open wider, your pupils dilate and your pulse begins to race. That’s exactly how it should be. Viper is the ultimate American Supercar.", vehicle.Description);
            Assert.AreEqual("inventory-x-2.jpg", vehicle.ImageFileName);
            Assert.AreEqual(92125M, vehicle.MSRP);
            Assert.AreEqual(90000M, vehicle.SalePrice);
        }

        [Test]
        public void NotFoundVehicleDetailsIsNull()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetDetailsById(9825);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddVehicleWithExistingMakeAndModel()
        {
            Vehicle vehicleToAdd = new Vehicle();
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var vehicleRepo = new VehiclesRepositoryADO();
            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var modelsCount = modelRepo.GetAll().Count();
            var makesCount = makeRepo.GetAll().Count();

            vehicleToAdd.VIN = "66666666666666666";
            carMakeToAdd.Name = "Mazda";
            carModelToAdd.Name = "MAZDA5";
            vehicleToAdd.ModelYear = 2012;
            vehicleToAdd.Mileage = 104000;
            vehicleToAdd.TransmissionTypeId = 1;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.ColorId = 8;
            vehicleToAdd.InteriorColorId = 4;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.Description = "Super sweet van!";
            vehicleToAdd.ImageFileName = "image5.jpg";
            vehicleToAdd.MSRP = 8500M;
            vehicleToAdd.SalePrice = 7900M;
            vehicleToAdd.EmployeeId = 1;

            vehicleRepo.Insert(vehicleToAdd, carModelToAdd, carMakeToAdd);

            var vehicles = vehicleRepo.GetAll().ToList();

            Assert.AreEqual(7, vehicles.Count);

            Assert.AreEqual(7, vehicles[1].VehicleId);
            Assert.AreEqual("66666666666666666", vehicles[1].VIN);
            Assert.AreEqual(2012, vehicles[1].ModelYear);
            Assert.AreEqual(472, vehicles[1].ModelId);
            Assert.AreEqual(104000, vehicles[1].Mileage);
            Assert.AreEqual(1, vehicles[1].TransmissionTypeId);
            Assert.AreEqual(4, vehicles[1].BodyStyleId);
            Assert.AreEqual(8, vehicles[1].ColorId);
            Assert.AreEqual(4, vehicles[1].InteriorColorId);
            Assert.AreEqual(2, vehicles[1].VehicleTypeId);
            Assert.AreEqual("Super sweet van!", vehicles[1].Description);
            Assert.AreEqual("image5.jpg", vehicles[1].ImageFileName);
            Assert.AreEqual(8500M, vehicles[1].MSRP);
            Assert.AreEqual(7900M, vehicles[1].SalePrice);
            Assert.AreEqual(1, vehicles[1].EmployeeId);
            Assert.That(vehicles[1].DateAdded, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.IsFalse(vehicles[1].IsFeatured);
            Assert.IsFalse(vehicles[1].IsSold);

            var newModelsCount = modelRepo.GetAll().Count();
            var newMakesCount = makeRepo.GetAll().Count();

            Assert.AreEqual(makesCount, newMakesCount);
            Assert.AreEqual(modelsCount, newModelsCount);
        }

        [Test]
        public void CanAddVehicleWithNewMakeAndModel()
        {
            Vehicle vehicleToAdd = new Vehicle();
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var vehicleRepo = new VehiclesRepositoryADO();
            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var modelsCount = modelRepo.GetAll().Count();
            var makesCount = makeRepo.GetAll().Count();

            vehicleToAdd.VIN = "66666666666666666";
            carMakeToAdd.Name = "Zoltan";
            carModelToAdd.Name = "Party Van";
            vehicleToAdd.ModelYear = 2012;
            vehicleToAdd.Mileage = 104000;
            vehicleToAdd.TransmissionTypeId = 1;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.ColorId = 8;
            vehicleToAdd.InteriorColorId = 4;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.Description = "Super sweet van!";
            vehicleToAdd.ImageFileName = "image5.jpg";
            vehicleToAdd.MSRP = 8500M;
            vehicleToAdd.SalePrice = 7900M;
            vehicleToAdd.EmployeeId = 1;

            vehicleRepo.Insert(vehicleToAdd, carModelToAdd, carMakeToAdd);

            var vehicles = vehicleRepo.GetAll().ToList();

            Assert.AreEqual(7, vehicles.Count);

            Assert.AreEqual(7, vehicles[1].VehicleId);
            Assert.AreEqual("66666666666666666", vehicles[1].VIN);
            Assert.AreEqual(2012, vehicles[1].ModelYear);
            Assert.AreEqual(689, vehicles[1].ModelId);
            Assert.AreEqual(104000, vehicles[1].Mileage);
            Assert.AreEqual(1, vehicles[1].TransmissionTypeId);
            Assert.AreEqual(4, vehicles[1].BodyStyleId);
            Assert.AreEqual(8, vehicles[1].ColorId);
            Assert.AreEqual(4, vehicles[1].InteriorColorId);
            Assert.AreEqual(2, vehicles[1].VehicleTypeId);
            Assert.AreEqual("Super sweet van!", vehicles[1].Description);
            Assert.AreEqual("image5.jpg", vehicles[1].ImageFileName);
            Assert.AreEqual(8500M, vehicles[1].MSRP);
            Assert.AreEqual(7900M, vehicles[1].SalePrice);
            Assert.AreEqual(1, vehicles[1].EmployeeId);
            Assert.That(vehicles[1].DateAdded, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.IsFalse(vehicles[1].IsFeatured);
            Assert.IsFalse(vehicles[1].IsSold);

            var newModelsCount = modelRepo.GetAll().Count();
            var newMakesCount = makeRepo.GetAll().Count();

            Assert.AreEqual(makesCount + 1, newMakesCount);
            Assert.AreEqual(modelsCount + 1, newModelsCount);

            var newModel = modelRepo.GetById(689);

            Assert.AreEqual("Party Van", newModel.Name);
            Assert.AreEqual(63, newModel.MakeId);

            var newMake = makeRepo.GetById(63);

            Assert.AreEqual("Zoltan", newMake.Name);
        }

        [Test]
        public void CanAddVehicleWithExistingMakeNewModel()
        {
            Vehicle vehicleToAdd = new Vehicle();
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var vehicleRepo = new VehiclesRepositoryADO();
            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var modelsCount = modelRepo.GetAll().Count();
            var makesCount = makeRepo.GetAll().Count();

            vehicleToAdd.VIN = "66666666666666666";
            carMakeToAdd.MakeId = 1;
            carMakeToAdd.Name = "Acura";
            carModelToAdd.Name = "Aardvark";
            vehicleToAdd.ModelYear = 2012;
            vehicleToAdd.Mileage = 104000;
            vehicleToAdd.TransmissionTypeId = 1;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.ColorId = 8;
            vehicleToAdd.InteriorColorId = 4;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.Description = "Super sweet van!";
            vehicleToAdd.ImageFileName = "image5.jpg";
            vehicleToAdd.MSRP = 8500M;
            vehicleToAdd.SalePrice = 7900M;
            vehicleToAdd.EmployeeId = 1;

            vehicleRepo.Insert(vehicleToAdd, carModelToAdd, carMakeToAdd);

            var vehicles = vehicleRepo.GetAll().ToList();

            Assert.AreEqual(7, vehicles.Count);

            Assert.AreEqual(7, vehicles[1].VehicleId);
            Assert.AreEqual("66666666666666666", vehicles[1].VIN);
            Assert.AreEqual(2012, vehicles[1].ModelYear);
            Assert.AreEqual(689, vehicles[1].ModelId);
            Assert.AreEqual(104000, vehicles[1].Mileage);
            Assert.AreEqual(1, vehicles[1].TransmissionTypeId);
            Assert.AreEqual(4, vehicles[1].BodyStyleId);
            Assert.AreEqual(8, vehicles[1].ColorId);
            Assert.AreEqual(4, vehicles[1].InteriorColorId);
            Assert.AreEqual(2, vehicles[1].VehicleTypeId);
            Assert.AreEqual("Super sweet van!", vehicles[1].Description);
            Assert.AreEqual("image5.jpg", vehicles[1].ImageFileName);
            Assert.AreEqual(8500M, vehicles[1].MSRP);
            Assert.AreEqual(7900M, vehicles[1].SalePrice);
            Assert.AreEqual(1, vehicles[1].EmployeeId);
            Assert.That(vehicles[1].DateAdded, Is.EqualTo(DateTime.Now).Within(2).Seconds);
            Assert.IsFalse(vehicles[1].IsFeatured);
            Assert.IsFalse(vehicles[1].IsSold);

            var newModelsCount = modelRepo.GetAll().Count();
            var newMakesCount = makeRepo.GetAll().Count();

            Assert.AreEqual(makesCount, newMakesCount);
            Assert.AreEqual(modelsCount + 1, newModelsCount);

            var newModel = modelRepo.GetById(689);

            Assert.AreEqual("Aardvark", newModel.Name);
            Assert.AreEqual(1, newModel.MakeId);
        }

        [Test]
        public void CanDeleteVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var vehicleRepo = new VehiclesRepositoryADO();

            vehicleToAdd.VIN = "66666666666666666";
            carMakeToAdd.Name = "Mazda";
            carModelToAdd.Name = "MAZDA5";
            vehicleToAdd.ModelYear = 2012;
            vehicleToAdd.Mileage = 104000;
            vehicleToAdd.TransmissionTypeId = 1;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.ColorId = 8;
            vehicleToAdd.InteriorColorId = 4;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.Description = "Super sweet van!";
            vehicleToAdd.ImageFileName = "image5.jpg";
            vehicleToAdd.MSRP = 8500M;
            vehicleToAdd.SalePrice = 7900M;
            vehicleToAdd.EmployeeId = 1;

            vehicleRepo.Insert(vehicleToAdd, carModelToAdd, carMakeToAdd);

            var loaded = vehicleRepo.GetById(7);

            Assert.IsNotNull(loaded);

            vehicleRepo.Delete(7);

            loaded = vehicleRepo.GetById(7);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CannotDeletePurchasedVehicle()
        {
            var repo = new VehiclesRepositoryADO();

            repo.Delete(4);

            var vehicle = repo.GetById(4);

            Assert.IsNotNull(vehicle);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            Special specialToAdd = new Special();
            var repo = new SpecialsRepositoryADO();

            specialToAdd.Title = "Black Friday Special";
            specialToAdd.Description = "We are even open on Thanksgiving!";

            repo.Insert(specialToAdd);

            var loaded = repo.GetById(4);

            Assert.IsNotNull(loaded);

            repo.Delete(5);

            loaded = repo.GetById(5);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanUpdateVehicleWithExistingMakeAndModel()
        {
            Vehicle vehicleToAdd = new Vehicle();
            CarModel carModelToAdd = new CarModel();
            CarMake carMakeToAdd = new CarMake();

            var vehicleRepo = new VehiclesRepositoryADO();
            var modelRepo = new CarModelsRepositoryADO();
            var makeRepo = new CarMakesRepositoryADO();

            var modelsCount = modelRepo.GetAll().Count();
            var makesCount = makeRepo.GetAll().Count();

            vehicleToAdd.VIN = "66666666666666666";
            carMakeToAdd.Name = "Mazda";
            carModelToAdd.Name = "MAZDA5";
            vehicleToAdd.ModelYear = 2012;
            vehicleToAdd.Mileage = 104000;
            vehicleToAdd.TransmissionTypeId = 1;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.ColorId = 8;
            vehicleToAdd.InteriorColorId = 4;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.Description = "Super sweet van!";
            vehicleToAdd.ImageFileName = "image5.jpg";
            vehicleToAdd.MSRP = 8500M;
            vehicleToAdd.SalePrice = 7900M;
            vehicleToAdd.EmployeeId = 1;

            vehicleRepo.Insert(vehicleToAdd, carModelToAdd, carMakeToAdd);

            Assert.IsNotNull(vehicleToAdd);

            vehicleToAdd = vehicleRepo.GetById(7);

            vehicleToAdd.VehicleId = 7;
            vehicleToAdd.VIN = "66666666666666666";
            carMakeToAdd.Name = "Mazda";
            carModelToAdd.Name = "MAZDA5";
            vehicleToAdd.ModelYear = 2012;
            vehicleToAdd.Mileage = 105000;
            vehicleToAdd.TransmissionTypeId = 1;
            vehicleToAdd.BodyStyleId = 4;
            vehicleToAdd.ColorId = 8;
            vehicleToAdd.InteriorColorId = 4;
            vehicleToAdd.VehicleTypeId = 2;
            vehicleToAdd.Description = "Super sweet van!";
            vehicleToAdd.ImageFileName = "inventory-x-7.jpg";
            vehicleToAdd.MSRP = 8500M;
            vehicleToAdd.SalePrice = 7500M;
            vehicleToAdd.EmployeeId = 1;
            vehicleToAdd.IsFeatured = true;

            vehicleRepo.Update(vehicleToAdd, carModelToAdd, carMakeToAdd);

            Assert.AreEqual(7, vehicleToAdd.VehicleId);
            Assert.AreEqual("66666666666666666", vehicleToAdd.VIN);
            Assert.AreEqual(2012, vehicleToAdd.ModelYear);
            Assert.AreEqual(472, vehicleToAdd.ModelId);
            Assert.AreEqual(105000, vehicleToAdd.Mileage);
            Assert.AreEqual(1, vehicleToAdd.TransmissionTypeId);
            Assert.AreEqual(4, vehicleToAdd.BodyStyleId);
            Assert.AreEqual(8, vehicleToAdd.ColorId);
            Assert.AreEqual(4, vehicleToAdd.InteriorColorId);
            Assert.AreEqual(2, vehicleToAdd.VehicleTypeId);
            Assert.AreEqual("Super sweet van!", vehicleToAdd.Description);
            Assert.AreEqual("inventory-x-7.jpg", vehicleToAdd.ImageFileName);
            Assert.AreEqual(8500M, vehicleToAdd.MSRP);
            Assert.AreEqual(7500M, vehicleToAdd.SalePrice);
            Assert.AreEqual(1, vehicleToAdd.EmployeeId);
            Assert.IsTrue(vehicleToAdd.IsFeatured);
            Assert.IsFalse(vehicleToAdd.IsSold);

            var newModelsCount = modelRepo.GetAll().Count();
            var newMakesCount = makeRepo.GetAll().Count();

            Assert.AreEqual(makesCount, newMakesCount);
            Assert.AreEqual(modelsCount, newModelsCount);
        }

    }
}
