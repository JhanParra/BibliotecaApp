using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaApp.Clases
{
    internal class EditorialRepositorio
    {
        private string connectionString = "Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;";

        public bool Insertar(Editorial editorial)
        {
            string query = "INSERT INTO EDITORIAL (Nombre, Estado) VALUES (@nombre, @estado)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre", editorial.Nombre);
                cmd.Parameters.AddWithValue("@estado", editorial.Estado);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Editorial Insertar: " + ex.Message); return false; }
            }
        }

        public bool Actualizar(Editorial editorial)
        {
            string query = "UPDATE EDITORIAL SET Nombre = @nombre WHERE editorialID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id",     editorial.EditorialID);
                cmd.Parameters.AddWithValue("@nombre", editorial.Nombre);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Editorial Actualizar: " + ex.Message); return false; }
            }
        }

        public bool Eliminar(Editorial editorial)
        {
            string query = "DELETE FROM EDITORIAL WHERE editorialID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", editorial.EditorialID);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Editorial Eliminar: " + ex.Message); return false; }
            }
        }

        public DataTable ObtenerTodos()
        {
            string query = "SELECT editorialID, Nombre FROM EDITORIAL WHERE Estado = 1";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error Editorial Obtener: " + ex.Message); }
                return dt;
            }
        }

        // ── Valida si ya existe una editorial con el mismo Nombre ──
        public bool Existe(string nombre, int idExcluir = 0)
        {
            string query = @"SELECT COUNT(*) FROM EDITORIAL
                              WHERE LTRIM(RTRIM(Nombre)) = @nombre
                                AND Estado = 1
                                AND editorialID <> @idExcluir";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                try { con.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0; }
                catch (Exception ex) { MessageBox.Show("Error Editorial Existe: " + ex.Message); return false; }
            }
        }
    }
}
