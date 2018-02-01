using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class NoExistingListItemAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is State)
            {
                State checkExistingState = (State)value;

                if (StateRepository.GetAll().Any(s => s.StateAbbreviation.ToUpper() == checkExistingState.StateAbbreviation.ToUpper()))
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }

            else if (value is Major)
            {
                Major checkExistingMajor = (Major)value;

                if (checkExistingMajor.MajorName != null && MajorRepository.GetAll().Any(s => s.MajorName.ToUpper() == checkExistingMajor.MajorName.ToUpper()))
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }

            else if (value is Course)
            {
                Course checkExistingCourse = (Course)value;

                if (CourseRepository.GetAll().Any(s => s.CourseName.ToUpper() == checkExistingCourse.CourseName.ToUpper()))
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }

            return false;
        }
    }
}