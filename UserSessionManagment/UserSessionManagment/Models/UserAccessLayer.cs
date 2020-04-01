using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace UserSessionManagment.Models
{
    public class UserAccessLayer
    {
         
            public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            public List<UserModel> getData()
            {
                List<UserModel> usersList = new List<UserModel>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from [dbo].[UserTable]";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UserModel user = new UserModel();
                            user.Name = reader.GetValue(0).ToString();
                            user.Password = reader.GetValue(1).ToString();
                            usersList.Add(user);    
                        }
                    }
                }
                return usersList;
            }
      
    }
}