using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormReportes : Form
    {
        private PrestamoRepositorio repositorio = new PrestamoRepositorio();
        private string reporteActual = ""; // "fecha" o "usuarios" — para saber qué recargar al filtrar por estado

        public FormReportes() { InitializeComponent(); }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            Estilos.AplicarEstiloGrid(dgv);
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;

            // ── Combo de filtro por Estado ──
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Devuelto");
            cmbEstado.SelectedIndex = 0;
        }

        private void btnLibrosPorFecha_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            { MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            pnlFechas.Visible = true;
            lblReporte.Text   = "LIBROS PRESTADOS POR FECHA";
            reporteActual     = "fecha";

            CargarReporteFecha();
        }

        private void btnUsuariosMasPrestamos_Click(object sender, EventArgs e)
        {
            pnlFechas.Visible = false;
            lblReporte.Text   = "USUARIOS CON MÁS PRÉSTAMOS";
            reporteActual     = "usuarios";

            dgv.DataSource = repositorio.ReporteUsuariosMasPrestamos();
        }

        // ── Recarga el reporte de fechas aplicando el filtro de Estado ──
        private void CargarReporteFecha()
        {
            DataTable dt = repositorio.ReporteLibrosPorFecha(dtpDesde.Value.Date, dtpHasta.Value.Date);
            dgv.DataSource = FiltrarPorEstado(dt);
        }

        // ── Filtra el DataTable según el Estado seleccionado ──
        private DataTable FiltrarPorEstado(DataTable origen)
        {
            string estado = cmbEstado.SelectedItem?.ToString() ?? "Todos";
            if (estado == "Todos" || !origen.Columns.Contains("Estado"))
                return origen;

            DataTable filtrado = origen.Clone();
            foreach (DataRow row in origen.Rows)
                if (row["Estado"].ToString().Equals(estado, StringComparison.OrdinalIgnoreCase))
                    filtrado.ImportRow(row);

            return filtrado;
        }

        // ── Al cambiar el filtro de Estado, recarga el reporte activo ──
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reporteActual == "fecha")
                CargarReporteFecha();
            // El reporte de "usuarios" no tiene columna Estado, no se filtra
        }

        // ── Exportar a Excel el contenido actual del DataGridView ──
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgv.DataSource == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Genere un reporte primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter   = "Archivo Excel (*.xlsx)|*.xlsx";
                string nombreBase = lblReporte.Text.Replace(" ", "_");
                sfd.FileName = $"Reporte_{nombreBase}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportarDataGridViewAExcel(dgv, sfd.FileName, lblReporte.Text);
                        MessageBox.Show("✅ Reporte exportado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ── Lógica de exportación usando ClosedXML ──
        private void ExportarDataGridViewAExcel(DataGridView grid, string rutaArchivo, string tituloHoja)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var hoja = workbook.Worksheets.Add(string.IsNullOrWhiteSpace(tituloHoja) ? "Reporte" : tituloHoja.Substring(0, Math.Min(30, tituloHoja.Length)));

                // Título arriba
                hoja.Cell(1, 1).Value = tituloHoja;
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 14;
                hoja.Cell(2, 1).Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";
                hoja.Cell(2, 1).Style.Font.Italic = true;
                hoja.Cell(2, 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.Gray;

                int filaInicio = 4;

                // Encabezados
                for (int c = 0; c < grid.Columns.Count; c++)
                {
                    var celda = hoja.Cell(filaInicio, c + 1);
                    celda.Value = grid.Columns[c].HeaderText;
                    celda.Style.Font.Bold = true;
                    celda.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(26, 82, 118);
                    celda.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                }

                // Datos
                for (int f = 0; f < grid.Rows.Count; f++)
                {
                    for (int c = 0; c < grid.Columns.Count; c++)
                    {
                        var valor = grid.Rows[f].Cells[c].Value;
                        var celda = hoja.Cell(filaInicio + 1 + f, c + 1);

                        if (valor == null || valor == DBNull.Value)
                            celda.Value = "";
                        else if (valor is DateTime dt)
                            celda.Value = dt;
                        else if (decimal.TryParse(valor.ToString(), out decimal dec))
                            celda.Value = dec;
                        else
                            celda.Value = valor.ToString();
                    }
                }

                hoja.Columns().AdjustToContents();
                workbook.SaveAs(rutaArchivo);
            }
        }
    }
}
