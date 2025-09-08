using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


string connectionString = @"Data Source=LAPTOP-PMTNM0HV\hp;Initial Catalog=wiprojuly2025;TrustServerCertificate=True; Integrated Security=True";

    using (SqlConnection connection = new SqlConnection(connectionString)) {
        connection.Open();
        SqlCommand cmd = new SqlCommand

("select * from Employee where empid>1002 order by empname", connection);

SqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())

{

Console.WriteLine($"ID: {reader["empid"]}, Name: {reader["city"]}, Salary:{reader["city"]}");

}
        }