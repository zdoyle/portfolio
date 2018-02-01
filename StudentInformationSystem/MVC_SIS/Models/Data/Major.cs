using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    [NoExistingListItem(ErrorMessage = "Major already exists in database.  Add new major or return to list.")]
    public class Major
    {
        public int MajorId { get; set; }
        [Required(ErrorMessage = "You must give a major or return to list.")]
        public string MajorName { get; set; }
    }
}