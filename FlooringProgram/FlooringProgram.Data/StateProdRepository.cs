using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{
    public class StateProdRepository : IStateRepository
    {
        private string _filePath;

        public StateProdRepository(string baseFilePath)
        {
            _filePath = baseFilePath + "Taxes.txt";
        }

        public List<State> GetListOfStates()
        {
            List<State> states = CreateStateListFromFile();

            return states;
        }

        public State GetSingleState(string stateAbbreviation)
        {
            List<State> states = CreateStateListFromFile();

            foreach (var state in states)
            {
                if (stateAbbreviation == state.StateAbbreviation)
                {
                    return state;
                }
            }

            return null;
        }

        private List<State> CreateStateListFromFile()
        {
            List<State> states = new List<State>();

            if (File.Exists(_filePath))
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        State singleState = new State();

                        string[] columns = line.Split(',');

                        singleState.StateAbbreviation = columns[0];
                        singleState.StateName = columns[1];
                        singleState.TaxRate = decimal.Parse(columns[2]);

                        states.Add(singleState);
                    }
                }

                return states;
            }

            return null;
        }
    }
}
