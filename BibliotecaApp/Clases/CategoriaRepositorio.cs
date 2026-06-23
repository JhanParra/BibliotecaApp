using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaApp.Clases
{
    internal class CategoriaRepositorio
    {
        private string connectionString = "Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;";

        public bool Insertar(Categoria categoria)
        {
            string query = "INSERT INTO CATEGORIA (Nombre, Estado) VALUES (@nombre, @estado)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@estado", categoria.Estado);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Categoria Insertar: " + ex.Message); return false; }
            }
        }

        public bool Actualizar(Categoria categoria)
        {
            string query = "UPDATE CATEGORIA SET Nombre = @nombre WHERE categoriaID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id",     categoria.CategoriaID);
                cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Categoria Actualizar: " + ex.Message); return false; }
            }
        }

        public bool Eliminar(Categoria categoria)
        {
            string query = "DELETE FROM CATEGORIA WHERE categoriaID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", categoria.CategoriaID);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Categoria Eliminar: " + ex.Message); return false; }
            }
        }

        public DataTable ObtenerTodos()
        {
            string query = "SELECT categoriaID, Nombre FROM CATEGORIA WHERE Estado = 1";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error Categoria Obtener: " + ex.Message); }
                return dt;
            }
        }
        public bool Existe(string nombre, int idExcluir = 0)
        {
            string query = @"SELECT COUNT(*) FROM CATEGORIA
                              WHERE LTRIM(RTRIM(Nombre)) = @nombre
                                AND Estado = 1
                                AND categoriaID <> @idExcluir";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                try { con.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0; }
                catch (Exception ex) { MessageBox.Show("Error Categoria Existe: " + ex.Message); return false; }
            }
        }
    }
}
