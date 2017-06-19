using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public class StateTestRepository : IStateRepository
    {
        List<State> states = new List<State>();

        private static State _state1 = new State()
        {
            StateAbbreviation = "KY",
            StateName = "Kentucky",
            TaxRate = 6.00M
        };

        private static State _state2 = new State()
        {
            StateAbbreviation = "TN",
            StateName = "Tennessee",
            TaxRate = 10.00M
        };

        public StateTestRepository()
        {
            states.Add(_state1);
            states.Add(_state2);
        }

        public State GetSingleState(string stateAbbreviation)
        {
            foreach (var state in states)
            {
                if (stateAbbreviation == state.StateAbbreviation)
                {
                    return state;
                }
            }

            return null;
        }

        public List<State> GetListOfStates()
        {
            return states;
        }
    }
}
