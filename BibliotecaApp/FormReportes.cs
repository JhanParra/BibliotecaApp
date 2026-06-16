using System;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormReportes : Form
    {
        private PrestamoRepositorio repositorio = new PrestamoRepositorio();

        public FormReportes() { InitializeComponent(); }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            Estilos.AplicarEstiloGrid(dgv);
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
        }

        private void btnLibrosPorFecha_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            { MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            pnlFechas.Visible = true;
            lblReporte.Text   = "LIBROS PRESTADOS POR FECHA";
            dgv.DataSource    = repositorio.ReporteLibrosPorFecha(dtpDesde.Value.Date, dtpHasta.Value.Date);
        }

        private void btnUsuariosMasPrestamos_Click(object sender, EventArgs e)
        {
            pnlFechas.Visible = false;
            lblReporte.Text   = "USUARIOS CON MÁS PRÉSTAMOS";
            dgv.DataSource    = repositorio.ReporteUsuariosMasPrestamos();
        }
    }
}
