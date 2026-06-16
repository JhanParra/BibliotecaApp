using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaApp.Clases
{
    internal class LibroRepositorio
    {
        private string connectionString = "Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;";

        public bool Insertar(Libro libro)
        {
            string query = @"INSERT INTO LIBRO (ISBN, Titulo, autorID, categoriaID, editorialID, Stock, Estado)
                             VALUES (@isbn, @titulo, @autorID, @categoriaID, @editorialID, @stock, @estado)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@isbn",        libro.ISBN);
                cmd.Parameters.AddWithValue("@titulo",      libro.Titulo);
                cmd.Parameters.AddWithValue("@autorID",     libro.AutorID);
                cmd.Parameters.AddWithValue("@categoriaID", libro.CategoriaID);
                cmd.Parameters.AddWithValue("@editorialID", libro.EditorialID);
                cmd.Parameters.AddWithValue("@stock",       libro.Stock);
                cmd.Parameters.AddWithValue("@estado",      libro.Estado);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Libro Insertar: " + ex.Message); return false; }
            }
        }

        public bool Actualizar(Libro libro)
        {
            string query = @"UPDATE LIBRO SET Titulo = @titulo, autorID = @autorID,
                             categoriaID = @categoriaID, editorialID = @editorialID,
                             Stock = @stock WHERE ISBN = @isbn";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@isbn",        libro.ISBN);
                cmd.Parameters.AddWithValue("@titulo",      libro.Titulo);
                cmd.Parameters.AddWithValue("@autorID",     libro.AutorID);
                cmd.Parameters.AddWithValue("@categoriaID", libro.CategoriaID);
                cmd.Parameters.AddWithValue("@editorialID", libro.EditorialID);
                cmd.Parameters.AddWithValue("@stock",       libro.Stock);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Libro Actualizar: " + ex.Message); return false; }
            }
        }

        public bool Eliminar(Libro libro)
        {
            string query = "DELETE FROM LIBRO WHERE ISBN = @isbn";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@isbn", libro.ISBN);
                try { con.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show("Error Libro Eliminar: " + ex.Message); return false; }
            }
        }

        // Todos los libros activos (para FormLibros)
        public DataTable ObtenerTodos()
        {
            string query = @"SELECT L.libroID, L.ISBN, L.Titulo,
                                    A.Nombre + ' ' + A.Apellido AS Autor,
                                    C.Nombre AS Categoria,
                                    E.Nombre AS Editorial,
                                    L.Stock
                             FROM LIBRO L
                             INNER JOIN AUTOR     A ON L.autorID     = A.autorID
                             INNER JOIN CATEGORIA C ON L.categoriaID = C.categoriaID
                             INNER JOIN EDITORIAL E ON L.editorialID = E.editorialID
                             WHERE L.Estado = 1";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error Libro ObtenerTodos: " + ex.Message); }
                return dt;
            }
        }

        // Libros filtrados por categoría (para FormPrestamos)
        public DataTable ObtenerPorCategoria(int categoriaID)
        {
            string query = @"SELECT L.libroID, L.Titulo, L.Stock
                             FROM LIBRO L
                             WHERE L.categoriaID = @categoriaID
                             AND L.Estado = 1
                             AND L.Stock > 0";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                DataTable dt = new DataTable();
                try { con.Open(); da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error Libro ObtenerPorCategoria: " + ex.Message); }
                return dt;
            }
        }
    }
}
