namespace BibliotecaApp
{
    partial class FormPrestamos
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader        = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.lblSubtitulo     = new System.Windows.Forms.Label();
            this.pnlAlertaUsuario = new System.Windows.Forms.Panel();
            this.lblAlertaUsuario = new System.Windows.Forms.Label();
            this.pnlFormulario    = new System.Windows.Forms.Panel();
            this.lblDNIBuscar     = new System.Windows.Forms.Label();
            this.txtBuscarDNI     = new System.Windows.Forms.TextBox();
            this.lblOpciones      = new System.Windows.Forms.Label();
            this.lblUsuario       = new System.Windows.Forms.Label();
            this.lblCategoria     = new System.Windows.Forms.Label();
            this.lblLibro         = new System.Windows.Forms.Label();
            this.lblStock         = new System.Windows.Forms.Label();
            this.lblDevolucion    = new System.Windows.Forms.Label();
            this.lblDiasInfo      = new System.Windows.Forms.Label();
            this.cmbUsuario       = new System.Windows.Forms.ComboBox();
            this.cmbCategoria     = new System.Windows.Forms.ComboBox();
            this.cmbLibro         = new System.Windows.Forms.ComboBox();
            this.dtpDevolucion    = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar     = new System.Windows.Forms.Button();
            this.pnlTabla         = new System.Windows.Forms.Panel();
            this.lblTablaTitulo   = new System.Windows.Forms.Label();
            this.dgvPrestamos     = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // ── Header ───────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 82, 118);
            this.pnlHeader.Location  = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size      = new System.Drawing.Size(680, 65);

            this.lblTitulo.Text      = "REGISTRO DE PRÉSTAMO";
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.AutoSize  = true;

            this.lblSubtitulo.Text      = "Complete los datos para registrar un nuevo préstamo";
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(174, 214, 241);
            this.lblSubtitulo.Location  = new System.Drawing.Point(20, 38);
            this.lblSubtitulo.AutoSize  = true;

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblSubtitulo });

            // ── Panel alerta ─────────────────────────────────
            this.pnlAlertaUsuario.BackColor = System.Drawing.Color.FromArgb(253, 237, 236);
            this.pnlAlertaUsuario.Location  = new System.Drawing.Point(15, 75);
            this.pnlAlertaUsuario.Size      = new System.Drawing.Size(650, 32);
            this.pnlAlertaUsuario.Visible   = false;

            this.lblAlertaUsuario.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAlertaUsuario.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblAlertaUsuario.Location  = new System.Drawing.Point(10, 8);
            this.lblAlertaUsuario.AutoSize  = true;

            this.pnlAlertaUsuario.Controls.Add(this.lblAlertaUsuario);

            // ── Panel formulario ─────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location  = new System.Drawing.Point(15, 115);
            this.pnlFormulario.Size      = new System.Drawing.Size(650, 285);

            // Buscar por DNI (arriba)
            this.lblDNIBuscar.Text     = "Buscar DNI:";
            this.lblDNIBuscar.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDNIBuscar.Location = new System.Drawing.Point(15, 18);
            this.lblDNIBuscar.AutoSize = true;

            this.txtBuscarDNI.Location        = new System.Drawing.Point(115, 15);
            this.txtBuscarDNI.Size            = new System.Drawing.Size(150, 25);
            this.txtBuscarDNI.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscarDNI.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDNI.MaxLength       = 8;
            this.txtBuscarDNI.PlaceholderText = "Ingrese DNI...";
            this.txtBuscarDNI.TextChanged    += new System.EventHandler(this.txtBuscarDNI_TextChanged);
            this.txtBuscarDNI.KeyDown        += new System.Windows.Forms.KeyEventHandler(this.txtBuscarDNI_KeyDown);

            this.lblOpciones.Text      = "o seleccione abajo:";
            this.lblOpciones.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblOpciones.ForeColor = System.Drawing.Color.Gray;
            this.lblOpciones.Location  = new System.Drawing.Point(275, 19);
            this.lblOpciones.AutoSize  = true;

            // Usuario combo — muestra SOLO el nombre
            this.lblUsuario.Text     = "Usuario:";
            this.lblUsuario.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(15, 55);
            this.lblUsuario.AutoSize = true;

            this.cmbUsuario.Location      = new System.Drawing.Point(115, 52);
            this.cmbUsuario.Size          = new System.Drawing.Size(490, 25);
            this.cmbUsuario.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);

            // Categoría
            this.lblCategoria.Text     = "Categoría:";
            this.lblCategoria.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.Location = new System.Drawing.Point(15, 92);
            this.lblCategoria.AutoSize = true;

            this.cmbCategoria.Location      = new System.Drawing.Point(115, 89);
            this.cmbCategoria.Size          = new System.Drawing.Size(490, 25);
            this.cmbCategoria.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);

            // Libro
            this.lblLibro.Text     = "Libro:";
            this.lblLibro.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLibro.Location = new System.Drawing.Point(15, 129);
            this.lblLibro.AutoSize = true;

            this.cmbLibro.Location      = new System.Drawing.Point(115, 126);
            this.cmbLibro.Size          = new System.Drawing.Size(490, 25);
            this.cmbLibro.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLibro.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLibro.SelectedIndexChanged += new System.EventHandler(this.cmbLibro_SelectedIndexChanged);

            this.lblStock.Text      = "Stock disponible: -";
            this.lblStock.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblStock.ForeColor = System.Drawing.Color.Gray;
            this.lblStock.Location  = new System.Drawing.Point(115, 153);
            this.lblStock.AutoSize  = true;

            // Fecha devolución
            this.lblDevolucion.Text     = "Devolución:";
            this.lblDevolucion.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDevolucion.Location = new System.Drawing.Point(15, 180);
            this.lblDevolucion.AutoSize = true;

            this.dtpDevolucion.Location = new System.Drawing.Point(115, 177);
            this.dtpDevolucion.Size     = new System.Drawing.Size(200, 25);
            this.dtpDevolucion.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDevolucion.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblDiasInfo.Text      = "Por defecto 7 días  |  Multa: S/ 1.50 por día de retraso";
            this.lblDiasInfo.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblDiasInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblDiasInfo.Location  = new System.Drawing.Point(115, 205);
            this.lblDiasInfo.AutoSize  = true;

            // Botón registrar
            this.btnRegistrar.Text      = "✅  REGISTRAR PRÉSTAMO";
            this.btnRegistrar.Location  = new System.Drawing.Point(115, 235);
            this.btnRegistrar.Size      = new System.Drawing.Size(220, 38);
            this.btnRegistrar.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Click    += new System.EventHandler(this.btnRegistrar_Click);

            this.pnlFormulario.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDNIBuscar, txtBuscarDNI, lblOpciones,
                lblUsuario, cmbUsuario,
                lblCategoria, cmbCategoria,
                lblLibro, cmbLibro, lblStock,
                lblDevolucion, dtpDevolucion, lblDiasInfo,
                btnRegistrar });

            // ── Panel tabla historial ─────────────────────────
            this.pnlTabla.BackColor = System.Drawing.Color.White;
            this.pnlTabla.Location  = new System.Drawing.Point(15, 410);
            this.pnlTabla.Size      = new System.Drawing.Size(650, 250);
            this.pnlTabla.Visible   = false;

            this.lblTablaTitulo.Text      = "📋 Historial de préstamos del usuario";
            this.lblTablaTitulo.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaTitulo.ForeColor = System.Drawing.Color.FromArgb(26, 82, 118);
            this.lblTablaTitulo.Location  = new System.Drawing.Point(10, 8);
            this.lblTablaTitulo.AutoSize  = true;

            this.dgvPrestamos.Location            = new System.Drawing.Point(10, 30);
            this.dgvPrestamos.Size                = new System.Drawing.Size(630, 210);
            this.dgvPrestamos.AllowUserToAddRows  = false;
            this.dgvPrestamos.ReadOnly            = true;
            this.dgvPrestamos.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvPrestamos.RowHeadersVisible   = false;
            this.dgvPrestamos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 82, 118);
            this.dgvPrestamos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPrestamos.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPrestamos.EnableHeadersVisualStyles               = false;
            this.dgvPrestamos.RowTemplate.Height                      = 28;

            this.pnlTabla.Controls.AddRange(new System.Windows.Forms.Control[] { lblTablaTitulo, dgvPrestamos });

            // ── Form ─────────────────────────────────────────
            this.ClientSize      = new System.Drawing.Size(680, 675);
            this.BackColor       = System.Drawing.Color.FromArgb(236, 240, 241);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Registro de Préstamo";
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                pnlHeader, pnlAlertaUsuario, pnlFormulario, pnlTabla });
            this.Load += new System.EventHandler(this.FormPrestamos_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader, pnlAlertaUsuario, pnlFormulario, pnlTabla;
        private System.Windows.Forms.Label          lblTitulo, lblSubtitulo, lblAlertaUsuario;
        private System.Windows.Forms.Label          lblDNIBuscar, lblOpciones, lblUsuario, lblCategoria, lblLibro;
        private System.Windows.Forms.Label          lblStock, lblDevolucion, lblDiasInfo, lblTablaTitulo;
        private System.Windows.Forms.TextBox        txtBuscarDNI;
        private System.Windows.Forms.ComboBox       cmbUsuario, cmbCategoria, cmbLibro;
        private System.Windows.Forms.DateTimePicker dtpDevolucion;
        private System.Windows.Forms.Button         btnRegistrar;
        private System.Windows.Forms.DataGridView   dgvPrestamos;
    }
}
