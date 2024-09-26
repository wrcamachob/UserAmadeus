using Infraestructure.Entities;
using Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UsersRepository : IUsers
    {
        /// <summary>
        /// Cadena de conexion.
        /// </summary>
        private readonly string connection;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor.
        /// </summary>
        public UsersRepository(IConfiguration config)
        {
            _configuration = config;
            connection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> Add(UsersAmadeus entity)
        {
            using SqlConnection conn = new(connection);

            SqlCommand cmd = new()
            {
                Connection = conn,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "SPInsertUsersAm",
                CommandTimeout = 10
            };
            cmd.Parameters.AddWithValue("@IDIdentifier", entity.IDIdentifier);
            cmd.Parameters["@IDIdentifier"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters["@Name"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@LastName", entity.LastName);
            cmd.Parameters["@LastName"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;            
            cmd.Parameters.AddWithValue("@DateOfBirthday", entity.DateOfBirthday);
            cmd.Parameters["@DateOfBirthday"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@Salary", entity.Salary);
            cmd.Parameters["@Salary"].Direction = ParameterDirection.Input;
            await conn.OpenAsync();
            return cmd.ExecuteNonQuery();
        }

        public async Task<int> Delete(long id)
        {
            using (SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "DeleteUsers",
                    CommandTimeout = 10
                };
                cmd.Parameters.AddWithValue("@IDIdentifier", id);
                cmd.Parameters["@IDIdentifier"].Direction = ParameterDirection.Input;
                await conn.OpenAsync();
                return cmd.ExecuteNonQuery();
            }
        }

        public async Task<IEnumerable<UsersAmadeus>> GetAllUsers()
        {
            List<UsersAmadeus> lstUsers = new();
            using (SqlConnection conn = new(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "SPGetAllUsersAm",
                        CommandTimeout = 10
                    };
                    await conn.OpenAsync();

                    cmd.ExecuteScalar();
                    SqlDataReader dt = cmd.ExecuteReader();

                    while (dt.Read())
                    {
                        UsersAmadeus datUsers = new()
                        {
                            IDIdentifier = Convert.ToInt64(dt["USAMIDIdentifier"].ToString()),
                            Name = dt["USAMName"].ToString(),
                            LastName = dt["USAMLastName"].ToString(),
                            Email = dt["USAMEmail"].ToString(),
                            PhoneNumber = Convert.ToInt64(dt["USAMPhoneNumber"]),
                            DateOfBirthday = dt["USAMDateOfBirthday"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(dt["USAMDateOfBirthday"].ToString()), //DateTime.ParseExact(dt["USAMDateOfBirthday"].ToString(), "dd/MM/yyyy", null),
                            Salary = dt["USAMSalary"].ToString() == "" ? 0 : Convert.ToInt64(dt["USAMSalary"])
                        };
                        
                        lstUsers.Add(datUsers);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            return lstUsers;
        }

        public async Task<int> Update(UsersAmadeus entity)
        {
            //string mensaje = string.Empty;
            using (SqlConnection conn = new(connection))
            {

                SqlCommand cmd = new()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "SPUpdateUsersAm",
                    CommandTimeout = 10
                };
                cmd.Parameters.AddWithValue("@IDIdentifier", entity.IDIdentifier);
                cmd.Parameters["@IDIdentifier"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters["@Name"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters["@LastName"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;                
                cmd.Parameters.AddWithValue("@DateOfBirthday", entity.DateOfBirthday);
                cmd.Parameters["@DateOfBirthday"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@Salary", entity.Salary);
                cmd.Parameters["@Salary"].Direction = ParameterDirection.Input;
                await conn.OpenAsync();
                return cmd.ExecuteNonQuery();                              
            }            
        }
    }
}
