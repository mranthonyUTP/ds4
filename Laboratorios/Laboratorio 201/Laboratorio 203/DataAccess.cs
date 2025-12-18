using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD
{
    public class DataAccess
    {
        string connStr = ConfigurationManager.ConnectionStrings["PROD_TIENDA_DB"].ConnectionString;

        public DataTable GetAll()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos ORDER BY ID", con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataRow GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos WHERE ID=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                    return null;
                }
            }
        }

        public void Insert(int id, string nombre, decimal precio, int stock)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Productos (ID, NOMBRE, PRECIO, STOCK) VALUES(@ID,@N,@P,@S)", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@N", nombre);
                cmd.Parameters.AddWithValue("@P", precio);
                cmd.Parameters.AddWithValue("@S", stock);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(int id, string nombre, decimal precio, int stock)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Productos SET NOMBRE=@N, PRECIO=@P, STOCK=@S WHERE ID=@ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@N", nombre);
                cmd.Parameters.AddWithValue("@P", precio);
                cmd.Parameters.AddWithValue("@S", stock);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE ID=@ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}