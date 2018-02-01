using GuildCars.Data.Interfaces.CustomerRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.CustomerTables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.ADO.CustomerRepositories
{
    public class StatesRepositoryADO : IStatesRepository
    {
        public IEnumerable<State> GetAll()
        {
            List<State> states = new List<State>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateId = (byte)dr["StateId"];
                        currentRow.Abbreviation = dr["Abbreviation"].ToString();
                        currentRow.Name = dr["Name"].ToString();

                        states.Add(currentRow);
                    }
                }
            }

            return states;
        }

        public State GetById(byte stateId)
        {
            State state = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", stateId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        state = new State();
                        state.StateId = (byte)dr["StateId"];
                        state.Abbreviation = dr["Abbreviation"].ToString();
                        state.Name = dr["Name"].ToString();
                    }
                }
            }

            return state;
        }
    }
}
