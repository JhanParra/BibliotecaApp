using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormDevoluciones : Form
    {
        private PrestamoRepositorio repositorio = new PrestamoRepositorio();

        public FormDevoluciones() { InitializeComponent(); }

        private void FormDevoluciones_Load(object sender, EventArgs e)
        {
            Estilos.AplicarEstiloGrid(dgv);
            CargarPrestamos();
        }

        private void CargarPrestamos()
        {
            dgv.DataSource = repositorio.ObtenerActivos();
            ColorizarFilas();
        }

        private void ColorizarFilas()
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (fila.Cells["DiasRetraso"].Value != null &&
                    Convert.ToInt32(fila.Cells["DiasRetraso"].Value) > 0)
                {
                    // Rojo para vencidos
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(253, 237, 236);
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                    fila.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 57, 43);
                }
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int    prestamoID  = Convert.ToInt32(dgv.SelectedRows[0].Cells["prestamoID"].Value);
            int    diasRetraso = Convert.ToInt32(dgv.SelectedRows[0].Cells["DiasRetraso"].Value);
            decimal multaEstim = Convert.ToDecimal(dgv.SelectedRows[0].Cells["MultaEstimada"].Value);
            string usuario     = dgv.SelectedRows[0].Cells["Usuario"].Value?.ToString();
            string libro       = dgv.SelectedRows[0].Cells["Libro"].Value?.ToString();

            // Mensaje de confirmación con detalle de multa
            string msg = $"¿Confirmar devolución?\n\n" +
                         $"Usuario : {usuario}\n" +
                         $"Libro   : {libro}\n";

            if (diasRetraso > 0)
            {
                msg += $"\n⚠ RETRASO DE {diasRetraso} DÍA(S)\n" +
                       $"💰 Multa a cobrar: S/ {multaEstim:0.00}\n" +
                       $"   (S/ 1.50 por día de retraso)";
            }
            else
            {
                msg += "\n✅ Entrega a tiempo — sin multa.";
            }

            if (MessageBox.Show(msg, "Confirmar Devolución",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Prestamo p = new Prestamo("", 0, DateTime.Today);
                p.PrestamoID = prestamoID;

                ResultadoDevolucion resultado = p.MarcarDevuelto();

                if (resultado.Exito)
                {
                    string msgFinal = "✅ Devolución registrada correctamente.\n";
                    if (resultado.Multa > 0)
                        msgFinal += $"\n💰 Multa cobrada: S/ {resultado.Multa:0.00}\n" +
                                    $"   ({resultado.DiasRetraso} días de retraso)";
                    else
                        msgFinal += "\nSin multa — entregado a tiempo.";

                    MessageBox.Show(msgFinal, "Devolución Exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamos();
                }
                else
                {
                    MessageBox.Show("Error: " + resultado.Mensaje, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => CargarPrestamos();

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro)) { CargarPrestamos(); return; }

            DataTable todos    = repositorio.ObtenerActivos();
            DataTable filtrado = todos.Clone();
            foreach (DataRow row in todos.Rows)
                if (row["Usuario"].ToString().ToLower().Contains(filtro) ||
                    row["Libro"].ToString().ToLower().Contains(filtro)   ||
                    row["DNI"].ToString().ToLower().Contains(filtro))
                    filtrado.ImportRow(row);

            dgv.DataSource = filtrado;
            ColorizarFilas();
        }
    }
}
