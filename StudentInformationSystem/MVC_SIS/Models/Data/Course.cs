using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    [NoExistingListItem(ErrorMessage = "Course already exists in database.  Add new course or return to list.")]
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "You must enter a course or return to list.")]
        public string CourseName { get; set; }
    }
}