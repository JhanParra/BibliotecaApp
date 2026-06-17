using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaApp.Clases
{
    internal class UsuarioRepositorio
    {
        private string connectionString = "Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;";

        public bool Insertar(Usuario usuario)
        {
            string query = "INSERT INTO USUARIO (DNI, Nombre, Apellido, Telefono, Estado) VALUES (@dni, @nombre, @apellido, @telefono, @estado)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@dni",      usuario.DNI);
                cmd.Parameters.AddWithValue("@nombre",   usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@estado",   usuario.Estado);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Usuario Insertar: " + ex.Message); return false; }
            }
        }

        public bool Actualizar(Usuario usuario)
        {
            string query = "UPDATE USUARIO SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono WHERE DNI = @dni";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@dni",      usuario.DNI);
                cmd.Parameters.AddWithValue("@nombre",   usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Usuario Actualizar: " + ex.Message); return false; }
            }
        }

        public bool Eliminar(Usuario usuario)
        {
            string query = "DELETE FROM USUARIO WHERE DNI = @dni";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@dni", usuario.DNI);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Usuario Eliminar: " + ex.Message); return false; }
            }
        }

        public DataTable ObtenerTodos()
        {
            string query = "SELECT DNI, Nombre, Apellido, Telefono FROM USUARIO WHERE Estado = 1";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error Usuario Obtener: " + ex.Message); }
                return dt;
            }
        }

        // ── Valida si ya existe un usuario con ese DNI ──
        // El DNI es PK, así que esto se usa solo para REGISTRO (nunca en edición, el DNI no cambia)
        public bool ExisteDNI(string dni)
        {
            string query = "SELECT COUNT(*) FROM USUARIO WHERE DNI = @dni";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@dni", dni.Trim());
                try { con.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) > 0; }
                catch (Exception ex) { MessageBox.Show("Error Usuario ExisteDNI: " + ex.Message); return false; }
            }
        }
    }
}
