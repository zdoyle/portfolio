using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class StateNameAndAbbreviationMustMatchAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is State)
            {
                State checkState = (State)value;

                var matchingState = (from state in State.States
                                     where state.Value == checkState.StateAbbreviation &&
                                     state.Text.ToLower() == checkState.StateName.ToLower()
                                     select state).ToList();

                if (matchingState.Count() == 1)
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