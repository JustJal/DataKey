﻿using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class IDComparator : ConnectionToSQL
    {
        public bool IDSearch(string user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    /*Remember to change the name of YOUR table in the code below*/
                    command.CommandText = "select *from EmployeesInfo where ID =@user";
                    command.Parameters.AddWithValue("@user", user);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                        connection.Close();
                    return false;

                }
            }
        }
    }
}
