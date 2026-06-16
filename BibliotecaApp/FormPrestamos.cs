using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormPrestamos : Form
    {
        private PrestamoRepositorio  prestamoRepo = new PrestamoRepositorio();
        private LibroRepositorio     libroRepo    = new LibroRepositorio();
        private UsuarioRepositorio   usuarioRepo  = new UsuarioRepositorio();
        private CategoriaRepositorio catRepo      = new CategoriaRepositorio();
        private int  stockActual = 0;
        private bool cargando    = true;

        private static readonly DateTime FECHA_MAX = new DateTime(9998, 12, 31);

        public FormPrestamos() { InitializeComponent(); }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            cargando = true;

            dtpDevolucion.MaxDate = FECHA_MAX;
            dtpDevolucion.MinDate = DateTime.Today.AddDays(1);
            dtpDevolucion.Value   = DateTime.Today.AddDays(7);

            cmbUsuario.DisplayMember   = "DNI";    cmbUsuario.ValueMember   = "DNI";         cmbUsuario.DataSource   = usuarioRepo.ObtenerTodos();
            cmbCategoria.DisplayMember = "Nombre"; cmbCategoria.ValueMember = "categoriaID"; cmbCategoria.DataSource = catRepo.ObtenerTodos();

            cargando = false;
            ActualizarInfoUsuario();
        }

        // ── Búsqueda por DNI ─────────────────────────────────
        private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            string dni = txtBuscarDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni)) return;

            // Buscar en el combo
            foreach (DataRowView row in cmbUsuario.Items)
            {
                if (row["DNI"].ToString().StartsWith(dni))
                {
                    cmbUsuario.SelectedItem = row;
                    break;
                }
            }
        }

        private void txtBuscarDNI_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar Enter busca el DNI exacto
            if (e.KeyCode == Keys.Enter)
            {
                string dni = txtBuscarDNI.Text.Trim();
                bool encontrado = false;
                foreach (DataRowView row in cmbUsuario.Items)
                {
                    if (row["DNI"].ToString() == dni)
                    {
                        cmbUsuario.SelectedItem = row;
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                    MessageBox.Show($"No se encontró usuario con DNI: {dni}", "No encontrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarInfoUsuario()
        {
            if (cmbUsuario.SelectedValue == null) return;
            string dni = cmbUsuario.SelectedValue.ToString();

            // Sincronizar el txtBuscarDNI con el combo
            if (txtBuscarDNI.Text != dni)
                txtBuscarDNI.Text = dni;

            using (System.Data.SqlClient.SqlConnection con =
                new System.Data.SqlClient.SqlConnection("Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;"))
            {
                string query = @"
                    SELECT
                        COUNT(CASE WHEN Estado='Activo' THEN 1 END) AS LibrosActivos,
                        COUNT(CASE WHEN Estado='Activo' AND FechaDevolucion < GETDATE() THEN 1 END) AS Vencidos,
                        SUM(CASE WHEN Estado='Activo' AND FechaDevolucion < GETDATE()
                                 THEN DATEDIFF(DAY, FechaDevolucion, GETDATE()) * 1.50
                                 ELSE 0 END) AS MultaAcumulada
                    FROM PRESTAMO WHERE DNI_Usuario = @dni";

                using (System.Data.SqlClient.SqlCommand cmd =
                    new System.Data.SqlClient.SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    try
                    {
                        con.Open();
                        using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int     librosActivos = Convert.ToInt32(reader["LibrosActivos"]);
                                int     vencidos      = Convert.ToInt32(reader["Vencidos"]);
                                decimal multa         = Convert.ToDecimal(reader["MultaAcumulada"]);

                                if (vencidos > 0)
                                {
                                    lblAlertaUsuario.Text      = $"⛔ BLOQUEADO: {vencidos} préstamo(s) vencido(s) | Multa: S/ {multa:0.00}";
                                    pnlAlertaUsuario.BackColor = Color.FromArgb(253, 237, 236);
                                    lblAlertaUsuario.ForeColor = Color.FromArgb(192, 57, 43);
                                    pnlAlertaUsuario.Visible   = true;
                                    btnRegistrar.Enabled       = false;
                                    btnRegistrar.BackColor     = Color.Gray;
                                }
                                else if (librosActivos >= 2)
                                {
                                    lblAlertaUsuario.Text      = $"⛔ LÍMITE: ya tiene {librosActivos} libro(s). Máximo 2.";
                                    pnlAlertaUsuario.BackColor = Color.FromArgb(255, 243, 205);
                                    lblAlertaUsuario.ForeColor = Color.FromArgb(133, 77, 14);
                                    pnlAlertaUsuario.Visible   = true;
                                    btnRegistrar.Enabled       = false;
                                    btnRegistrar.BackColor     = Color.Gray;
                                }
                                else
                                {
                                    int restantes = 2 - librosActivos;
                                    if (librosActivos > 0)
                                    {
                                        lblAlertaUsuario.Text      = $"ℹ Tiene {librosActivos} libro(s). Puede pedir {restantes} más.";
                                        pnlAlertaUsuario.BackColor = Color.FromArgb(232, 244, 253);
                                        lblAlertaUsuario.ForeColor = Color.FromArgb(26, 82, 118);
                                        pnlAlertaUsuario.Visible   = true;
                                    }
                                    else
                                        pnlAlertaUsuario.Visible = false;

                                    btnRegistrar.Enabled   = true;
                                    btnRegistrar.BackColor = Color.FromArgb(39, 174, 96);
                                }
                            }
                        }
                    }
                    catch { pnlAlertaUsuario.Visible = false; }
                }
            }

            // Cargar tabla de préstamos del usuario
            CargarPrestamosUsuario(dni);
        }

        private void CargarPrestamosUsuario(string dni)
        {
            using (System.Data.SqlClient.SqlConnection con =
                new System.Data.SqlClient.SqlConnection("Server=localhost;Database=BDBIBLIOTECA;Trusted_Connection=True;"))
            {
                string query = @"
                    SELECT
                        L.Titulo        AS Libro,
                        P.FechaPrestamo AS [Fecha Préstamo],
                        P.FechaDevolucion AS [Fecha Devolución],
                        P.Estado,
                        CASE WHEN P.Estado='Activo' AND P.FechaDevolucion < GETDATE()
                             THEN DATEDIFF(DAY, P.FechaDevolucion, GETDATE())
                             ELSE 0 END AS [Días Retraso],
                        CASE WHEN P.Estado='Activo' AND P.FechaDevolucion < GETDATE()
                             THEN DATEDIFF(DAY, P.FechaDevolucion, GETDATE()) * 1.50
                             ELSE 0 END AS [Multa S/]
                    FROM PRESTAMO P
                    INNER JOIN LIBRO L ON P.libroID = L.libroID
                    WHERE P.DNI_Usuario = @dni
                    ORDER BY P.FechaPrestamo DESC";

                using (System.Data.SqlClient.SqlCommand cmd =
                    new System.Data.SqlClient.SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    try
                    {
                        con.Open();
                        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPrestamos.DataSource = dt;

                        // Colorear filas vencidas
                        foreach (DataGridViewRow fila in dgvPrestamos.Rows)
                        {
                            if (Convert.ToInt32(fila.Cells["Días Retraso"].Value) > 0)
                            {
                                fila.DefaultCellStyle.BackColor = Color.FromArgb(253, 237, 236);
                                fila.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                            }
                        }

                        // Mostrar u ocultar según si hay datos
                        pnlTabla.Visible = dt.Rows.Count > 0;
                        lblTablaTitulo.Text = dt.Rows.Count > 0
                            ? $"📋 Historial de préstamos del usuario ({dt.Rows.Count} registro(s))"
                            : "";
                    }
                    catch { pnlTabla.Visible = false; }
                }
            }
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            ActualizarInfoUsuario();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            if (cmbCategoria.SelectedValue == null) return;

            cargando = true;
            int categoriaID = Convert.ToInt32(cmbCategoria.SelectedValue);
            DataTable libros = libroRepo.ObtenerPorCategoria(categoriaID);
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember   = "libroID";
            cmbLibro.DataSource    = libros;
            cargando = false;

            ActualizarStock();
        }

        private void cmbLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            ActualizarStock();
        }

        private void ActualizarStock()
        {
            if (cmbLibro.SelectedItem == null) return;
            DataRowView row = cmbLibro.SelectedItem as DataRowView;
            if (row == null) return;

            stockActual = Convert.ToInt32(row["Stock"]);

            if (stockActual < 3)
            {
                lblStock.Text      = $"⚠ Stock limitado: {stockActual} unidad(es) — máximo 3 días";
                lblStock.ForeColor = Color.FromArgb(211, 84, 0);
                DateTime maxPermitido = DateTime.Today.AddDays(3);
                dtpDevolucion.MaxDate = maxPermitido;
                if (dtpDevolucion.Value > maxPermitido)
                    dtpDevolucion.Value = maxPermitido;
            }
            else
            {
                lblStock.Text         = $"Stock disponible: {stockActual} unidad(es)";
                lblStock.ForeColor    = Color.FromArgb(39, 174, 96);
                dtpDevolucion.MaxDate = FECHA_MAX;
                if (dtpDevolucion.Value < DateTime.Today.AddDays(4))
                    dtpDevolucion.Value = DateTime.Today.AddDays(7);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue == null || cmbLibro.SelectedValue == null)
            {
                MessageBox.Show("Seleccione usuario y libro.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDevolucion.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("La fecha de devolución debe ser posterior a hoy.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stockActual < 3)
            {
                int dias = (dtpDevolucion.Value.Date - DateTime.Today).Days;
                if (dias > 3)
                {
                    MessageBox.Show("Este libro tiene stock limitado.\nEl préstamo no puede exceder 3 días.",
                        "Stock Limitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Prestamo p = new Prestamo(
                cmbUsuario.SelectedValue.ToString(),
                Convert.ToInt32(cmbLibro.SelectedValue),
                dtpDevolucion.Value.Date
            );

            if (p.Registrar())
            {
                MessageBox.Show("✅ Préstamo registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar tabla y estado del usuario
                string dni = cmbUsuario.SelectedValue.ToString();
                ActualizarInfoUsuario();

                // Resetear libro
                cargando = true;
                cmbLibro.DataSource   = null;
                dtpDevolucion.MaxDate = FECHA_MAX;
                dtpDevolucion.Value   = DateTime.Today.AddDays(7);
                lblStock.Text         = "Stock disponible: -";
                cargando = false;
            }
        }
    }
}
