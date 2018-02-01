using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class MustBeValidStateName : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                State checkStateName = new State();

                checkStateName.StateName = (string)value;
                

                if (State.States.Any(s => s.Text.ToLower() == checkStateName.StateName.ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }
    }
}