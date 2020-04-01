using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserSessionManagment.Models
{
    public class RoleAccessLayer
    {
       
            public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            public List<UserRole> getData()
            {
                List<UserRole> roleList = new List<UserRole>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from [dbo].[UsersRole]";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UserRole role = new UserRole();
                            role.RoleId = Convert.ToInt32(reader.GetValue(0).ToString());
                            role.RoleName = reader.GetValue(1).ToString();
                            roleList.Add(role);
                        }
                    }
                }
                return roleList;
            }

        }
    }
