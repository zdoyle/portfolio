using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);



            //if (studentVM.Student.Major.MajorName == null)
            //{
            //    ModelState.Remove("E")
            //}

            if (!string.IsNullOrEmpty(studentVM.Student.LastName) && !string.IsNullOrEmpty(studentVM.Student.FirstName)
                && studentVM.Student.GPA >= 0.0M && studentVM.Student.GPA <= 4.0M)
            {
                ModelState.Where(x => x.Value.Errors.Count > 0).Select(d => d.Key).ToList().ForEach(g => ModelState.Remove(g));
            }

            if (ModelState.IsValid)
            {
                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }


        }

        [HttpGet]
        public ActionResult EditStudent(int StudentId)
        {
            var student = StudentRepository.Get(StudentId);

            var model = new StudentVM();
            model.SetCourseItems(CourseRepository.GetAll());
            model.SetMajorItems(MajorRepository.GetAll());
            model.SetStateItems(StateRepository.GetAll());

            if (student.Courses != null)
            {
                foreach (var course in student.Courses)
                {
                    model.SelectedCourseIds.Add(course.CourseId);
                }
            }
            model.Student = student;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();


            foreach (var id in studentVM.SelectedCourseIds)
            {
                studentVM.Student.Courses.Add(CourseRepository.Get(id));
            }


            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);


            studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);



            if (string.IsNullOrEmpty(studentVM.Student.FirstName))
            {
                ModelState.AddModelError("FirstName", "Please enter a First Name");
            }
            if (string.IsNullOrEmpty(studentVM.Student.LastName))
            {
                ModelState.AddModelError("LastName", "Please enter a Last Name");
            }



            if (studentVM.Student.Address.State == null)
            {
                ModelState.AddModelError("State", "Please select a State we offer services in");
            }


            if (ModelState.IsValid)
            {
                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int StudentId)
        {
            var student = StudentRepository.Get(StudentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}