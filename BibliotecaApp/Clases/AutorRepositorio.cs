using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaApp.Clases
{
    internal class AutorRepositorio
    {
        private string connectionString = "Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;";

        public bool Insertar(Autor autor)
        {
            string query = "INSERT INTO AUTOR (Nombre, Apellido, Estado) VALUES (@nombre, @apellido, @estado)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre",   autor.Nombre);
                cmd.Parameters.AddWithValue("@apellido", autor.Apellido);
                cmd.Parameters.AddWithValue("@estado",   autor.Estado);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Autor Insertar: " + ex.Message); return false; }
            }
        }

        public bool Actualizar(Autor autor)
        {
            string query = "UPDATE AUTOR SET Nombre = @nombre, Apellido = @apellido WHERE autorID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id",       autor.AutorID);
                cmd.Parameters.AddWithValue("@nombre",   autor.Nombre);
                cmd.Parameters.AddWithValue("@apellido", autor.Apellido);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Autor Actualizar: " + ex.Message); return false; }
            }
        }

        public bool Eliminar(Autor autor)
        {
            string query = "DELETE FROM AUTOR WHERE autorID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", autor.AutorID);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Autor Eliminar: " + ex.Message); return false; }
            }
        }

        public DataTable ObtenerTodos()
        {
            string query = "SELECT autorID, Nombre, Apellido FROM AUTOR WHERE Estado = 1";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error Autor Obtener: " + ex.Message); }
                return dt;
            }
        }
        public bool Existe(string nombre, string apellido, int idExcluir = 0)
        {
            string query = @"SELECT COUNT(*) FROM AUTOR
                              WHERE LTRIM(RTRIM(Nombre)) = @nombre
                                AND LTRIM(RTRIM(Apellido)) = @apellido
                                AND Estado = 1
                                AND autorID <> @idExcluir";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                cmd.Parameters.AddWithValue("@apellido", apellido.Trim());
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                try { con.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0; }
                catch (Exception ex) { MessageBox.Show("Error Autor Existe: " + ex.Message); return false; }
            }
        }
    }
}
