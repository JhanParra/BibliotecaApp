namespace BibliotecaApp
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader               = new System.Windows.Forms.Panel();
            this.lblTitulo               = new System.Windows.Forms.Label();
            this.lblSubtitulo            = new System.Windows.Forms.Label();
            this.pnlBotones              = new System.Windows.Forms.Panel();
            this.btnLibrosPorFecha       = new System.Windows.Forms.Button();
            this.btnUsuariosMasPrestamos = new System.Windows.Forms.Button();
            this.pnlFechas               = new System.Windows.Forms.Panel();
            this.lblDesde                = new System.Windows.Forms.Label();
            this.lblHasta                = new System.Windows.Forms.Label();
            this.dtpDesde                = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta                = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar              = new System.Windows.Forms.Button();
            this.lblEstado               = new System.Windows.Forms.Label();
            this.cmbEstado               = new System.Windows.Forms.ComboBox();
            this.pnlReporte              = new System.Windows.Forms.Panel();
            this.lblReporte              = new System.Windows.Forms.Label();
            this.btnExportarExcel        = new System.Windows.Forms.Button();
            this.dgv                     = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 82, 118);
            this.pnlHeader.Location  = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size      = new System.Drawing.Size(860, 65);
            this.lblTitulo.Text      = "REPORTES DEL SISTEMA";
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.AutoSize  = true;
            this.lblSubtitulo.Text      = "Consulte información estadística y de gestión";
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(174, 214, 241);
            this.lblSubtitulo.Location  = new System.Drawing.Point(20, 38);
            this.lblSubtitulo.AutoSize  = true;
            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblSubtitulo });

            // Panel botones
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Location  = new System.Drawing.Point(15, 80);
            this.pnlBotones.Size      = new System.Drawing.Size(830, 60);

            this.btnLibrosPorFecha.Text      = "Libros Prestados por Fecha";
            this.btnLibrosPorFecha.Location  = new System.Drawing.Point(15, 13);
            this.btnLibrosPorFecha.Size      = new System.Drawing.Size(230, 35);
            this.btnLibrosPorFecha.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLibrosPorFecha.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnLibrosPorFecha.ForeColor = System.Drawing.Color.White;
            this.btnLibrosPorFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibrosPorFecha.FlatAppearance.BorderSize = 0;
            this.btnLibrosPorFecha.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLibrosPorFecha.Click    += new System.EventHandler(this.btnLibrosPorFecha_Click);

            this.btnUsuariosMasPrestamos.Text      = "Usuarios con más Préstamos";
            this.btnUsuariosMasPrestamos.Location  = new System.Drawing.Point(260, 13);
            this.btnUsuariosMasPrestamos.Size      = new System.Drawing.Size(230, 35);
            this.btnUsuariosMasPrestamos.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUsuariosMasPrestamos.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnUsuariosMasPrestamos.ForeColor = System.Drawing.Color.White;
            this.btnUsuariosMasPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuariosMasPrestamos.FlatAppearance.BorderSize = 0;
            this.btnUsuariosMasPrestamos.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnUsuariosMasPrestamos.Click    += new System.EventHandler(this.btnUsuariosMasPrestamos_Click);

            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] { btnLibrosPorFecha, btnUsuariosMasPrestamos });

            // Panel fechas (+ filtro Estado)
            this.pnlFechas.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlFechas.Location  = new System.Drawing.Point(15, 150);
            this.pnlFechas.Size      = new System.Drawing.Size(830, 45);
            this.pnlFechas.Visible   = false;

            this.lblDesde.Text     = "Desde:";
            this.lblDesde.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.Location = new System.Drawing.Point(10, 13); this.lblDesde.AutoSize = true;

            this.dtpDesde.Location = new System.Drawing.Point(70, 10);
            this.dtpDesde.Size     = new System.Drawing.Size(150, 25);
            this.dtpDesde.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblHasta.Text     = "Hasta:";
            this.lblHasta.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.Location = new System.Drawing.Point(240, 13); this.lblHasta.AutoSize = true;

            this.dtpHasta.Location = new System.Drawing.Point(300, 10);
            this.dtpHasta.Size     = new System.Drawing.Size(150, 25);
            this.dtpHasta.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnFiltrar.Text      = "Filtrar";
            this.btnFiltrar.Location  = new System.Drawing.Point(465, 10);
            this.btnFiltrar.Size      = new System.Drawing.Size(80, 28);
            this.btnFiltrar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Click    += new System.EventHandler(this.btnLibrosPorFecha_Click);

            // ── Nuevo: filtro por Estado ──
            this.lblEstado.Text     = "Estado:";
            this.lblEstado.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(560, 13);
            this.lblEstado.AutoSize = true;

            this.cmbEstado.Location      = new System.Drawing.Point(615, 10);
            this.cmbEstado.Size          = new System.Drawing.Size(110, 25);
            this.cmbEstado.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);

            this.pnlFechas.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDesde, dtpDesde, lblHasta, dtpHasta, btnFiltrar, lblEstado, cmbEstado });

            // Panel título reporte (+ botón Exportar Excel)
            this.pnlReporte.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlReporte.Location  = new System.Drawing.Point(15, 205);
            this.pnlReporte.Size      = new System.Drawing.Size(830, 35);
            this.lblReporte.Text      = "Seleccione un reporte";
            this.lblReporte.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReporte.ForeColor = System.Drawing.Color.White;
            this.lblReporte.Location  = new System.Drawing.Point(15, 8);
            this.lblReporte.AutoSize  = true;

            // ── Nuevo: botón Exportar a Excel ──
            this.btnExportarExcel.Text      = "📊  Exportar a Excel";
            this.btnExportarExcel.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(33, 115, 70);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.FlatAppearance.BorderSize = 0;
            this.btnExportarExcel.Size      = new System.Drawing.Size(150, 27);
            this.btnExportarExcel.Location  = new System.Drawing.Point(665, 4);
            this.btnExportarExcel.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.Click    += new System.EventHandler(this.btnExportarExcel_Click);

            this.pnlReporte.Controls.AddRange(new System.Windows.Forms.Control[] { lblReporte, btnExportarExcel });

            // DataGridView
            this.dgv.Location            = new System.Drawing.Point(15, 250);
            this.dgv.Size                = new System.Drawing.Size(830, 320);
            this.dgv.AllowUserToAddRows  = false;
            this.dgv.ReadOnly            = true;
            this.dgv.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgv.RowHeadersVisible   = false;

            // Form
            this.ClientSize      = new System.Drawing.Size(860, 585);
            this.BackColor       = System.Drawing.Color.FromArgb(236, 240, 241);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Reportes del Sistema";
            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlHeader, pnlBotones, pnlFechas, pnlReporte, dgv });
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader, pnlBotones, pnlFechas, pnlReporte;
        private System.Windows.Forms.Label          lblTitulo, lblSubtitulo, lblDesde, lblHasta, lblReporte, lblEstado;
        private System.Windows.Forms.DateTimePicker dtpDesde, dtpHasta;
        private System.Windows.Forms.ComboBox       cmbEstado;
        private System.Windows.Forms.Button         btnLibrosPorFecha, btnUsuariosMasPrestamos, btnFiltrar, btnExportarExcel;
        private System.Windows.Forms.DataGridView   dgv;
    }
}
