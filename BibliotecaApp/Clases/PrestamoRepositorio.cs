using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaApp.Clases
{
    internal class PrestamoRepositorio
    {
        private string connectionString = "Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;";

        // Registra préstamo via SP (valida stock, usuario activo y mora)
        public bool Insertar(Prestamo prestamo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarPrestamo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI_Usuario",    prestamo.DNI_Usuario);
                cmd.Parameters.AddWithValue("@libroID",        prestamo.LibroID);
                cmd.Parameters.AddWithValue("@FechaDevolucion",prestamo.FechaDevolucion);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("⚠ " + ex.Message, "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Devuelve libro via SP (calcula multa y restaura stock)
        public ResultadoDevolucion MarcarDevuelto(int prestamoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarDevolucion", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prestamoID", prestamoID);
                cmd.Parameters.AddWithValue("@PorDia",     1.50m);
                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ResultadoDevolucion
                            {
                                Exito       = true,
                                Multa       = Convert.ToDecimal(reader["MultaGenerada"]),
                                DiasRetraso = Convert.ToInt32(reader["DiasRetraso"]),
                                Mensaje     = "Devolución registrada correctamente."
                            };
                        }
                    }
                    return new ResultadoDevolucion { Exito = true, Multa = 0, DiasRetraso = 0 };
                }
                catch (Exception ex)
                {
                    return new ResultadoDevolucion { Exito = false, Mensaje = ex.Message };
                }
            }
        }

        // Préstamos activos para devolución
        public DataTable ObtenerActivos()
        {
            string query = @"SELECT P.prestamoID,
                                    U.DNI,
                                    U.Nombre + ' ' + U.Apellido AS Usuario,
                                    L.Titulo AS Libro,
                                    P.FechaPrestamo,
                                    P.FechaDevolucion,
                                    CASE WHEN P.FechaDevolucion < GETDATE()
                                         THEN DATEDIFF(DAY, P.FechaDevolucion, GETDATE())
                                         ELSE 0 END AS DiasRetraso,
                                    CASE WHEN P.FechaDevolucion < GETDATE()
                                         THEN DATEDIFF(DAY, P.FechaDevolucion, GETDATE()) * 1.50
                                         ELSE 0 END AS MultaEstimada,
                                    P.Estado
                             FROM PRESTAMO P
                             INNER JOIN USUARIO U ON P.DNI_Usuario = U.DNI
                             INNER JOIN LIBRO   L ON P.libroID     = L.libroID
                             WHERE P.Estado = 'Activo'
                             ORDER BY P.FechaDevolucion ASC";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                return dt;
            }
        }

        // Reporte 1: Libros prestados por fecha
        // ── CORRECCIÓN: la multa ahora se calcula correctamente para préstamos
        //    activos vencidos (multa estimada en vivo) y para los ya devueltos
        //    (multa real cobrada en el momento de la devolución).
        public DataTable ReporteLibrosPorFecha(DateTime desde, DateTime hasta)
        {
            string query = @"SELECT L.Titulo, L.ISBN,
                                    U.Nombre + ' ' + U.Apellido AS Usuario,
                                    P.FechaPrestamo, P.FechaDevolucion,
                                    P.FechaDevolucionReal, P.Estado,
                                    CASE
                                        -- Ya devuelto: usa la multa real que se cobró
                                        WHEN P.Estado = 'Devuelto' THEN ISNULL(P.Multa, 0)
                                        -- Activo y vencido: calcula la multa estimada a la fecha de hoy
                                        WHEN P.Estado = 'Activo' AND P.FechaDevolucion < GETDATE()
                                            THEN DATEDIFF(DAY, P.FechaDevolucion, GETDATE()) * 1.50
                                        -- Activo y no vencido: sin multa
                                        ELSE 0
                                    END AS Multa
                             FROM PRESTAMO P
                             INNER JOIN LIBRO   L ON P.libroID     = L.libroID
                             INNER JOIN USUARIO U ON P.DNI_Usuario = U.DNI
                             WHERE P.FechaPrestamo BETWEEN @desde AND @hasta
                             ORDER BY P.FechaPrestamo DESC";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                DataTable dt = new DataTable();
                try { con.Open(); da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                return dt;
            }
        }

        // Reporte 2: Usuarios con más préstamos
        // ── CORRECCIÓN: TotalMultas ahora suma también la multa estimada
        //    de los préstamos activos vencidos, no solo las ya cobradas.
        public DataTable ReporteUsuariosMasPrestamos()
        {
            string query = @"SELECT U.DNI,
                                    U.Nombre + ' ' + U.Apellido AS Usuario,
                                    U.Telefono,
                                    COUNT(P.prestamoID)          AS TotalPrestamos,
                                    SUM(
                                        CASE
                                            WHEN P.Estado = 'Devuelto' THEN ISNULL(P.Multa, 0)
                                            WHEN P.Estado = 'Activo' AND P.FechaDevolucion < GETDATE()
                                                THEN DATEDIFF(DAY, P.FechaDevolucion, GETDATE()) * 1.50
                                            ELSE 0
                                        END
                                    ) AS TotalMultas,
                                    SUM(CASE WHEN P.Estado='Activo' AND P.FechaDevolucion < GETDATE()
                                             THEN 1 ELSE 0 END)  AS PrestamosVencidos
                             FROM PRESTAMO P
                             INNER JOIN USUARIO U ON P.DNI_Usuario = U.DNI
                             GROUP BY U.DNI, U.Nombre, U.Apellido, U.Telefono
                             ORDER BY TotalPrestamos DESC";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                return dt;
            }
        }

        // Stats para dashboard del menú
        public DataTable ObtenerEstadisticas()
        {
            string query = @"SELECT
                (SELECT COUNT(*) FROM LIBRO   WHERE Estado=1)                          AS TotalLibros,
                (SELECT COUNT(*) FROM USUARIO WHERE Estado=1)                          AS TotalUsuarios,
                (SELECT COUNT(*) FROM PRESTAMO WHERE Estado='Activo')                  AS PrestamosActivos,
                (SELECT COUNT(*) FROM PRESTAMO WHERE Estado='Activo'
                 AND FechaDevolucion < GETDATE())                                       AS PrestamosVencidos,
                (SELECT ISNULL(SUM(Multa),0) FROM PRESTAMO WHERE Estado='Devuelto')   AS TotalMultasRecaudadas";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) { MessageBox.Show("Error stats: " + ex.Message); }
                return dt;
            }
        }
    }
}
