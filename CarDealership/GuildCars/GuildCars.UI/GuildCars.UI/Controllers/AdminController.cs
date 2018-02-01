using GuildCars.Data.ADO.AdminRepositories;
using GuildCars.Data.ADO.VehicleRepositories;
using GuildCars.Data.Factories.AdminRepositories;
using GuildCars.Data.Factories.VehicleRepositories;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables.AdminTables;
using GuildCars.Models.Tables.VehicleTables;
using GuildCars.UI.Models;
using GuildCars.UI.Models.Extensions;
using GuildCars.UI.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Users()
        {
            var repo = EmployeesRepositoryFactory.GetRepository();

            var model = repo.GetUserDetailsAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            var model = repo.GetDetailsAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult MakesModels()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Makes()
        {
            var viewModel = new MakesVM();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Makes(MakesVM makesVM)
        {
            if (ModelState.IsValid)
            {
                var repo = CarMakesRepositoryFactory.GetRepository();

                var make = new CarMake();

                make.Name = makesVM.MakeName;

                repo.Insert(make);

                return RedirectToAction("Makes");
            }

            return View("Makes", makesVM);
        }

        [HttpGet]
        public ActionResult Models()
        {
            var viewModel = new ModelsVM();

            viewModel.SetMakeItems(CarMakesRepositoryFactory.GetRepository().GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Models(ModelsVM modelsVM)
        {
            if (ModelState.IsValid)
            {
                var repo = CarModelsRepositoryFactory.GetRepository();

                var model = new CarModel();
                var make = new CarMake();

                model.Name = modelsVM.ModelName;
                make.MakeId = modelsVM.MakeId;

                repo.Insert(model, make);

                return RedirectToAction("Models");
            }

            return View("Models", modelsVM);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var viewModel = new SpecialVM();

            viewModel.SetSpecials(SpecialsRepositoryFactory.GetRepository().GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Specials(SpecialVM specialVM)
        {
            if (ModelState.IsValid)
            {
                var repo = SpecialsRepositoryFactory.GetRepository();

                var special = new Special();

                special.Title = specialVM.Title;
                special.Description = specialVM.Description;

                repo.Insert(special);

                return RedirectToAction("Specials");
            }

            return View("Specials", specialVM);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var makesRepo = CarMakesRepositoryFactory.GetRepository();
            var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var transmissionTypesRepo = TransmissionTypesRepositoryFactory.GetRepository();
            var colorsRepo = ColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();

            var viewModel = new AddVehicleVM();

            viewModel.SetMakeItems(makesRepo.GetAll());
            viewModel.SetVehicleTypeItems(vehicleTypesRepo.GetAll());
            viewModel.SetBodyStyleItems(bodyStylesRepo.GetAll());
            viewModel.SetTransmissionTypeItems(transmissionTypesRepo.GetAll());
            viewModel.SetColorItems(colorsRepo.GetAll());
            viewModel.SetInteriorColorItems(interiorColorsRepo.GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleVM addVehicleVM)
        {
            var duplicateVehicle = from v in VehiclesRepositoryFactory.GetRepository().GetAll()
                                   where v.VIN == addVehicleVM.VIN
                                   select v;

            if (duplicateVehicle.Count() != 0)
            {
                ModelState.AddModelError("VIN", "VIN already exists in database. Duplicate vehicles are not allowed.");
            }

            if (ModelState.IsValid)
            {
                var vehicleToAdd = new Vehicle();
                var modelToAdd = new CarModel();
                var makeToAdd = new CarMake();

                var employeeId = int.Parse(User.Identity.GetEmployeeId());

                vehicleToAdd.EmployeeId = employeeId;

                var repo = VehiclesRepositoryFactory.GetRepository();

                if (addVehicleVM.File != null && addVehicleVM.File.ContentLength > 0)
                {
                    var newId = repo.GetAll().Max(v => v.VehicleId) + 1;

                    var fileSplit = Path.GetFileName(addVehicleVM.File.FileName).Split('.');

                    var fileExtension = fileSplit[fileSplit.Length - 1];

                    var fileName = "inventory-x-" + newId + "." + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    addVehicleVM.File.SaveAs(path);

                    vehicleToAdd.ImageFileName = fileName;
                }

                modelToAdd.Name = addVehicleVM.ModelName;
                makeToAdd.Name = addVehicleVM.MakeName;
                vehicleToAdd.VIN = addVehicleVM.VIN;
                vehicleToAdd.BodyStyleId = addVehicleVM.BodyStyleId;
                vehicleToAdd.ModelYear = addVehicleVM.ModelYear;
                vehicleToAdd.TransmissionTypeId = addVehicleVM.TransmissionTypeId;
                vehicleToAdd.ColorId = addVehicleVM.ColorId;
                vehicleToAdd.InteriorColorId = addVehicleVM.InteriorColorId;
                vehicleToAdd.Mileage = addVehicleVM.Mileage;
                vehicleToAdd.MSRP = addVehicleVM.MSRP;
                vehicleToAdd.SalePrice = addVehicleVM.SalePrice;
                vehicleToAdd.Description = addVehicleVM.Description;
                vehicleToAdd.VehicleTypeId = addVehicleVM.VehicleTypeId;


                repo.Insert(vehicleToAdd, modelToAdd, makeToAdd);

                return RedirectToAction("Vehicles");
            }

            var makesRepo = CarMakesRepositoryFactory.GetRepository();
            var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var transmissionTypesRepo = TransmissionTypesRepositoryFactory.GetRepository();
            var colorsRepo = ColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
            var modelsRepo = CarModelsRepositoryFactory.GetRepository();

            addVehicleVM.SetMakeItems(makesRepo.GetAll());
            addVehicleVM.SetVehicleTypeItems(vehicleTypesRepo.GetAll());
            addVehicleVM.SetBodyStyleItems(bodyStylesRepo.GetAll());
            addVehicleVM.SetTransmissionTypeItems(transmissionTypesRepo.GetAll());
            addVehicleVM.SetColorItems(colorsRepo.GetAll());
            addVehicleVM.SetInteriorColorItems(interiorColorsRepo.GetAll());
            addVehicleVM.SetMakeModelItems(modelsRepo.GetDetailsAll());

            return View("AddVehicle", addVehicleVM);
        }

        [HttpGet]
        public ActionResult UpdateVehicle(int id)
        {
            var makesRepo = CarMakesRepositoryFactory.GetRepository();
            var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var transmissionTypesRepo = TransmissionTypesRepositoryFactory.GetRepository();
            var colorsRepo = ColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
            var vehiclesRepo = VehiclesRepositoryFactory.GetRepository();
            var modelsRepo = CarModelsRepositoryFactory.GetRepository();

            var viewModel = new UpdateVehicleVM();

            viewModel.SetMakeItems(makesRepo.GetAll());
            viewModel.SetVehicleTypeItems(vehicleTypesRepo.GetAll());
            viewModel.SetBodyStyleItems(bodyStylesRepo.GetAll());
            viewModel.SetTransmissionTypeItems(transmissionTypesRepo.GetAll());
            viewModel.SetColorItems(colorsRepo.GetAll());
            viewModel.SetInteriorColorItems(interiorColorsRepo.GetAll());
            viewModel.SetMakeModelItems(modelsRepo.GetDetailsAll());

            var vehicleToUpdate = vehiclesRepo.GetById(id);
            var modelToUpdate = modelsRepo.GetById(vehicleToUpdate.ModelId);
            var makeToUpdate = makesRepo.GetById(modelToUpdate.MakeId);

            viewModel.VehicleId = vehicleToUpdate.VehicleId;
            viewModel.VIN = vehicleToUpdate.VIN;
            viewModel.ModelName = modelToUpdate.Name;
            viewModel.MakeName = makeToUpdate.Name;
            viewModel.VehicleTypeId = vehicleToUpdate.VehicleTypeId;
            viewModel.BodyStyleId = vehicleToUpdate.BodyStyleId;
            viewModel.ModelYear = vehicleToUpdate.ModelYear;
            viewModel.TransmissionTypeId = vehicleToUpdate.TransmissionTypeId;
            viewModel.ColorId = vehicleToUpdate.ColorId;
            viewModel.InteriorColorId = vehicleToUpdate.InteriorColorId;
            viewModel.Mileage = vehicleToUpdate.Mileage;
            viewModel.MSRP = vehicleToUpdate.MSRP;
            viewModel.SalePrice = vehicleToUpdate.SalePrice;
            viewModel.Description = vehicleToUpdate.Description;
            viewModel.IsFeatured = vehicleToUpdate.IsFeatured;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateVehicle(UpdateVehicleVM updateVehicleVM)
        {
            if (ModelState.IsValid)
            {
                var originalVehicle = VehiclesRepositoryFactory.GetRepository().GetDetailsById(updateVehicleVM.VehicleId);

                var vehicleToUpdate = new Vehicle();
                var modelToUpdate = new CarModel();
                var makeToUpdate = new CarMake();

                var employeeId = int.Parse(User.Identity.GetEmployeeId());

                vehicleToUpdate.EmployeeId = employeeId;

                var repo = VehiclesRepositoryFactory.GetRepository();

                if (updateVehicleVM.File != null && updateVehicleVM.File.ContentLength > 0)
                {
                    var newId = repo.GetAll().Max(v => v.VehicleId) + 1;

                    var fileSplit = Path.GetFileName(updateVehicleVM.File.FileName).Split('.');

                    var fileExtension = fileSplit[fileSplit.Length - 1];

                    var fileName = "inventory-x-" + newId + "." + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    updateVehicleVM.File.SaveAs(path);

                    vehicleToUpdate.ImageFileName = fileName;
                }

                else
                {
                    vehicleToUpdate.ImageFileName = originalVehicle.ImageFileName;
                }

                vehicleToUpdate.VehicleId = updateVehicleVM.VehicleId;
                vehicleToUpdate.VIN = updateVehicleVM.VIN;
                modelToUpdate.Name = updateVehicleVM.ModelName;
                makeToUpdate.Name = updateVehicleVM.MakeName;
                vehicleToUpdate.VehicleTypeId = updateVehicleVM.VehicleTypeId;
                vehicleToUpdate.BodyStyleId = updateVehicleVM.BodyStyleId;
                vehicleToUpdate.ModelYear = updateVehicleVM.ModelYear;
                vehicleToUpdate.TransmissionTypeId = updateVehicleVM.TransmissionTypeId;
                vehicleToUpdate.ColorId = updateVehicleVM.ColorId;
                vehicleToUpdate.InteriorColorId = updateVehicleVM.InteriorColorId;
                vehicleToUpdate.Mileage = updateVehicleVM.Mileage;
                vehicleToUpdate.MSRP = updateVehicleVM.MSRP;
                vehicleToUpdate.SalePrice = updateVehicleVM.SalePrice;
                vehicleToUpdate.Description = updateVehicleVM.Description;
                vehicleToUpdate.IsFeatured = updateVehicleVM.IsFeatured;

                repo.Update(vehicleToUpdate, modelToUpdate, makeToUpdate);

                return RedirectToAction("Vehicles");
            }

            var makesRepo = CarMakesRepositoryFactory.GetRepository();
            var vehicleTypesRepo = VehicleTypesRepositoryFactory.GetRepository();
            var bodyStylesRepo = BodyStylesRepositoryFactory.GetRepository();
            var transmissionTypesRepo = TransmissionTypesRepositoryFactory.GetRepository();
            var colorsRepo = ColorsRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorsRepositoryFactory.GetRepository();
            var vehiclesRepo = VehiclesRepositoryFactory.GetRepository();
            var modelsRepo = CarModelsRepositoryFactory.GetRepository();

            updateVehicleVM.SetMakeItems(makesRepo.GetAll());
            updateVehicleVM.SetVehicleTypeItems(vehicleTypesRepo.GetAll());
            updateVehicleVM.SetBodyStyleItems(bodyStylesRepo.GetAll());
            updateVehicleVM.SetTransmissionTypeItems(transmissionTypesRepo.GetAll());
            updateVehicleVM.SetColorItems(colorsRepo.GetAll());
            updateVehicleVM.SetInteriorColorItems(interiorColorsRepo.GetAll());
            updateVehicleVM.SetMakeModelItems(modelsRepo.GetDetailsAll());

            return View("UpdateVehicle", updateVehicleVM);
        }

        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var viewModel = new UpdateUserVM();
            var employee = EmployeesRepositoryFactory.GetRepository().GetById(id);
            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            viewModel.FirstName = employee.FirstName;
            viewModel.LastName = employee.LastName;
            viewModel.DepartmentId = employee.DepartmentId;
            viewModel.SetDepartmentItems(DepartmentsRepositoryFactory.GetRepository().GetAll());
            viewModel.Email = UserManager.Users.Where(u => u.EmployeeId == id).FirstOrDefault().Email;
            viewModel.IsDisabled = UserManager.Users.Where(u => u.EmployeeId == id).FirstOrDefault().IsDisabled;
            viewModel.EmployeeId = employee.EmployeeId;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateUser(UpdateUserVM vm)
        {
            var repo = EmployeesRepositoryFactory.GetRepository();

            var employeeToUpdate = repo.GetById(vm.EmployeeId);

            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = UserManager.Users.Where(u => u.EmployeeId == vm.EmployeeId).FirstOrDefault();

            employeeToUpdate.FirstName = vm.FirstName;
            employeeToUpdate.LastName = vm.LastName;
            employeeToUpdate.DepartmentId = vm.DepartmentId;

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(vm.NewPassword))
                {
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(vm.NewPassword);
                    var result = UserManager.Update(user);
                }

                repo.Update(employeeToUpdate, vm.Email, vm.IsDisabled);

                return RedirectToAction("Users"); 
            }

            vm.NewPassword = "";
            vm.ConfirmNewPassword = "";

            vm.SetDepartmentItems(DepartmentsRepositoryFactory.GetRepository().GetAll());

            return View("UpdateUser", vm);
        }

        [HttpPost]
        public ActionResult Delete(int vehicleId)
        {
            var repo = VehiclesRepositoryFactory.GetRepository();

            var vehicle = repo.GetDetailsById(vehicleId);

            var imageFileName = vehicle.ImageFileName;

            repo.Delete(vehicleId);

            if ((System.IO.File.Exists(Path.Combine(Server.MapPath("~/Images/"), imageFileName))))
            {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/"), imageFileName));
            }

            return RedirectToAction("Vehicles");
        }

    }
}