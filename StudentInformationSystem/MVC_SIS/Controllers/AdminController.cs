using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                major.MajorName = myTI.ToTitleCase(major.MajorName);

                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors"); 
            }

            return View("AddMajor", major);
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (ModelState.IsValid)
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                state.StateName = myTI.ToTitleCase(state.StateName);
                state.StateAbbreviation = myTI.ToTitleCase(state.StateAbbreviation);

                StateRepository.Add(state);
                return RedirectToAction("States"); 
            }

            return View("AddState", state);
        }

        [HttpGet]
        public ActionResult EditState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            StateRepository.Edit(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        [ActionName("DeleteState")]
        public ActionResult DeleteStatePost(string id)
        {
            StateRepository.Delete(id);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                course.CourseName = myTI.ToTitleCase(course.CourseName);

                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses"); 
            }

            return View("AddCourse", course);
        }

        //edit view is empty
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult DeleteCourse(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        [ActionName("DeleteCourse")]
        public ActionResult DeleteCoursePost(int id)
        {
            CourseRepository.Delete(id);
            return RedirectToAction("Courses");
        }
    }
}