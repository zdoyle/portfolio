using GuildCars.Data.Interfaces.AdminRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.AdminTables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.ADO.AdminRepositories
{
    public class DepartmentsRepositoryADO : IDepartmentsRepository
    {
        public IEnumerable<Department> GetAll()
        {
            List<Department> departments = new List<Department>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DepartmentsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Department currentRow = new Department();
                        currentRow.DepartmentId = (byte)dr["DepartmentId"];
                        currentRow.Name = dr["Name"].ToString();

                        departments.Add(currentRow);
                    }
                }
            }

            return departments;
        }

        public Department GetById(byte departmentId)
        {
            Department department = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DepartmentsSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        department = new Department();
                        department.DepartmentId = (byte)dr["DepartmentId"];
                        department.Name = dr["Name"].ToString();
                    }
                }
            }

            return department;
        }
    }
}
