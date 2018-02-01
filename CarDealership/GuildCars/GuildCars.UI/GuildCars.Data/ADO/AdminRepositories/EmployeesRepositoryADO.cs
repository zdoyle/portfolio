using GuildCars.Data.Interfaces.AdminRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables.AdminTables;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Queries;

namespace GuildCars.Data.ADO.AdminRepositories
{
    public class EmployeesRepositoryADO : IEmployeesRepository
    {
        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee currentRow = new Employee();
                        currentRow.EmployeeId = (int)dr["EmployeeId"];
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.DepartmentId = (byte)dr["DepartmentId"];

                        employees.Add(currentRow);
                    }
                }
            }

            return employees;
        }

        public Employee GetById(int employeeId)
        {
            Employee contact = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeesSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        contact = new Employee();
                        contact.EmployeeId = (int)dr["EmployeeId"];
                        contact.FirstName = dr["FirstName"].ToString();
                        contact.LastName = dr["LastName"].ToString();
                        contact.DepartmentId = (byte)dr["DepartmentId"];
                    }
                }
            }

            return contact;
        }

        public IEnumerable<UserRequestItem> GetUserDetailsAll()
        {
            List<UserRequestItem> request = new List<UserRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersSelectAllDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserRequestItem currentRow = new UserRequestItem();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.EmployeeId = (int)dr["EmployeeId"];
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.RoleId = dr["RoleId"].ToString();
                        currentRow.Role = dr["Role"].ToString();

                        request.Add(currentRow);
                    }
                }
            }

            return request;
        }

        public void Insert(Employee employee)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@EmployeeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);

                cn.Open();

                cmd.ExecuteNonQuery();

                employee.EmployeeId = (int)param.Value;
            }
        }

        public void Update(Employee employee, string emailAddress, bool isDisabled)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                cmd.Parameters.AddWithValue("@IsDisabled", isDisabled);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
