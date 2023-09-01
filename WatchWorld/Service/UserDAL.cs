using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WatchWorld.Models;

namespace WatchWorld.Service
{
    public class UserDAL
    {
        SqlConnection connectionLink = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        
        SqlCommand command;

        SqlDataAdapter adapter;

        DataTable table;

        public List<UserModel> GetUsers()
        {
            command = new SqlCommand("sp_select",connectionLink);
            command.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            List<UserModel> list = new List<UserModel>();
            foreach(DataRow table in  table.Rows) 
            {
                list.Add(new UserModel
                {
                    Id = Convert.ToInt32(table["Id"]),
                    Name = table["Name"].ToString(),
                    Email = table["Email"].ToString(),
                    Age = Convert.ToInt32(table["Age"]),

                });
            }
            return list;
        }

        public bool InsertUser(UserModel user)
        {
            try
            {
                command = new SqlCommand("sp_insert", connectionLink);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@age", user.Age);

                connectionLink.Open();
                int r = command.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateUser(UserModel user)
        {
            try
            {
                command = new SqlCommand("sp_update", connectionLink);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@age", user.Age);
                command.Parameters.AddWithValue("@id", user.Id);

                connectionLink.Open();
                int r = command.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                command = new SqlCommand("sp_delete", connectionLink);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id",id);

                connectionLink.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}