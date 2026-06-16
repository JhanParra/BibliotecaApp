namespace BibliotecaApp
{
    partial class FormDevoluciones
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlBuscar    = new System.Windows.Forms.Panel();
            this.lblBuscar    = new System.Windows.Forms.Label();
            this.txtBuscar    = new System.Windows.Forms.TextBox();
            this.lblLeyenda   = new System.Windows.Forms.Label();
            this.dgv          = new System.Windows.Forms.DataGridView();
            this.pnlBotones   = new System.Windows.Forms.Panel();
            this.btnDevolver  = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblInfoMulta = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 82, 118);
            this.pnlHeader.Location  = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size      = new System.Drawing.Size(860, 65);

            this.lblTitulo.Text      = "DEVOLUCIÓN DE LIBROS";
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.AutoSize  = true;

            this.lblSubtitulo.Text      = "Seleccione un préstamo activo para registrar su devolución";
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(174, 214, 241);
            this.lblSubtitulo.Location  = new System.Drawing.Point(20, 38);
            this.lblSubtitulo.AutoSize  = true;

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblSubtitulo });

            // Panel búsqueda
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Location  = new System.Drawing.Point(0, 65);
            this.pnlBuscar.Size      = new System.Drawing.Size(860, 45);

            this.lblBuscar.Text     = "Buscar:";
            this.lblBuscar.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(15, 13);
            this.lblBuscar.AutoSize = true;

            this.txtBuscar.Location        = new System.Drawing.Point(75, 10);
            this.txtBuscar.Size            = new System.Drawing.Size(280, 25);
            this.txtBuscar.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.PlaceholderText = "Buscar por usuario, libro o DNI...";
            this.txtBuscar.TextChanged    += new System.EventHandler(this.txtBuscar_TextChanged);

            this.lblLeyenda.Text      = "🔴 Rojo = préstamo vencido con multa acumulada";
            this.lblLeyenda.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeyenda.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblLeyenda.Location  = new System.Drawing.Point(400, 14);
            this.lblLeyenda.AutoSize  = true;

            this.pnlBuscar.Controls.AddRange(new System.Windows.Forms.Control[] { lblBuscar, txtBuscar, lblLeyenda });

            // DataGridView
            this.dgv.Location            = new System.Drawing.Point(15, 120);
            this.dgv.Size                = new System.Drawing.Size(830, 320);
            this.dgv.AllowUserToAddRows  = false;
            this.dgv.ReadOnly            = true;
            this.dgv.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgv.RowHeadersVisible   = false;

            // Panel botones
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Location  = new System.Drawing.Point(0, 450);
            this.pnlBotones.Size      = new System.Drawing.Size(860, 65);

            this.btnDevolver.Text      = "✅  REGISTRAR DEVOLUCIÓN";
            this.btnDevolver.Location  = new System.Drawing.Point(15, 15);
            this.btnDevolver.Size      = new System.Drawing.Size(230, 38);
            this.btnDevolver.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDevolver.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnDevolver.ForeColor = System.Drawing.Color.White;
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolver.FlatAppearance.BorderSize = 0;
            this.btnDevolver.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnDevolver.Click    += new System.EventHandler(this.btnDevolver_Click);

            this.btnRefrescar.Text      = "🔄  Refrescar";
            this.btnRefrescar.Location  = new System.Drawing.Point(260, 15);
            this.btnRefrescar.Size      = new System.Drawing.Size(130, 38);
            this.btnRefrescar.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.Click    += new System.EventHandler(this.btnRefrescar_Click);

            this.lblInfoMulta.Text      = "💡 La multa es de S/ 1.50 por día de retraso y se cobra al momento de la devolución.";
            this.lblInfoMulta.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblInfoMulta.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoMulta.Location  = new System.Drawing.Point(420, 22);
            this.lblInfoMulta.AutoSize  = true;

            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] { btnDevolver, btnRefrescar, lblInfoMulta });

            // Form
            this.ClientSize      = new System.Drawing.Size(860, 515);
            this.BackColor       = System.Drawing.Color.FromArgb(236, 240, 241);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Devolución de Libros";
            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlHeader, pnlBuscar, dgv, pnlBotones });
            this.Load += new System.EventHandler(this.FormDevoluciones_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel           pnlHeader, pnlBuscar, pnlBotones;
        private System.Windows.Forms.Label           lblTitulo, lblSubtitulo, lblBuscar, lblLeyenda, lblInfoMulta;
        private System.Windows.Forms.TextBox         txtBuscar;
        private System.Windows.Forms.DataGridView    dgv;
        private System.Windows.Forms.Button          btnDevolver, btnRefrescar;
    }
}
