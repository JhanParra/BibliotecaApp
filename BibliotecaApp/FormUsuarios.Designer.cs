namespace BibliotecaApp
{
    partial class FormUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblSubtitulo    = new System.Windows.Forms.Label();
            this.pnlFormulario   = new System.Windows.Forms.Panel();
            this.lblDNI          = new System.Windows.Forms.Label();
            this.lblNombre       = new System.Windows.Forms.Label();
            this.lblApellido     = new System.Windows.Forms.Label();
            this.lblTelefono     = new System.Windows.Forms.Label();
            this.txtDNI          = new System.Windows.Forms.TextBox();
            this.txtNombre       = new System.Windows.Forms.TextBox();
            this.txtApellido     = new System.Windows.Forms.TextBox();
            this.txtTelefono     = new System.Windows.Forms.TextBox();
            this.btnRegistrar    = new System.Windows.Forms.Button();
            this.btnEditar       = new System.Windows.Forms.Button();
            this.btnEliminar     = new System.Windows.Forms.Button();
            this.btnLimpiar      = new System.Windows.Forms.Button();
            this.pnlBuscar       = new System.Windows.Forms.Panel();
            this.lblBuscar       = new System.Windows.Forms.Label();
            this.txtBuscar       = new System.Windows.Forms.TextBox();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.dgv             = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 82, 118);
            this.pnlHeader.Location  = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size      = new System.Drawing.Size(760, 65);
            this.lblTitulo.Text      = "GESTIÓN DE USUARIOS";
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 10);
            this.lblTitulo.AutoSize  = true;
            this.lblSubtitulo.Text      = "Registre y administre los socios de la biblioteca";
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(174, 214, 241);
            this.lblSubtitulo.Location  = new System.Drawing.Point(20, 38);
            this.lblSubtitulo.AutoSize  = true;
            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblSubtitulo });

            // Panel Formulario
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location  = new System.Drawing.Point(15, 80);
            this.pnlFormulario.Size      = new System.Drawing.Size(730, 148);

            this.lblDNI.Text      = "DNI:";
            this.lblDNI.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDNI.Location  = new System.Drawing.Point(15, 16);
            this.lblDNI.AutoSize  = true;
            this.txtDNI.Location    = new System.Drawing.Point(120, 13);
            this.txtDNI.Size        = new System.Drawing.Size(160, 25);
            this.txtDNI.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.MaxLength   = 8;

            this.lblNombre.Text      = "Nombre:";
            this.lblNombre.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location  = new System.Drawing.Point(15, 49);
            this.lblNombre.AutoSize  = true;
            this.txtNombre.Location    = new System.Drawing.Point(120, 46);
            this.txtNombre.Size        = new System.Drawing.Size(240, 25);
            this.txtNombre.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblApellido.Text      = "Apellido:";
            this.lblApellido.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.Location  = new System.Drawing.Point(15, 82);
            this.lblApellido.AutoSize  = true;
            this.txtApellido.Location    = new System.Drawing.Point(120, 79);
            this.txtApellido.Size        = new System.Drawing.Size(240, 25);
            this.txtApellido.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTelefono.Text      = "Teléfono:";
            this.lblTelefono.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location  = new System.Drawing.Point(15, 115);
            this.lblTelefono.AutoSize  = true;
            this.txtTelefono.Location    = new System.Drawing.Point(120, 112);
            this.txtTelefono.Size        = new System.Drawing.Size(160, 25);
            this.txtTelefono.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnRegistrar.Text      = "REGISTRAR";
            this.btnRegistrar.Location  = new System.Drawing.Point(430, 13);
            this.btnRegistrar.Size      = new System.Drawing.Size(140, 33);
            this.btnRegistrar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Click    += new System.EventHandler(this.btnRegistrar_Click);

            this.btnEditar.Text      = "EDITAR";
            this.btnEditar.Location  = new System.Drawing.Point(578, 13);
            this.btnEditar.Size      = new System.Drawing.Size(140, 33);
            this.btnEditar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(211, 84, 0);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Click    += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text      = "ELIMINAR";
            this.btnEliminar.Location  = new System.Drawing.Point(430, 54);
            this.btnEliminar.Size      = new System.Drawing.Size(140, 33);
            this.btnEliminar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Click    += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.Text      = "LIMPIAR";
            this.btnLimpiar.Location  = new System.Drawing.Point(578, 54);
            this.btnLimpiar.Size      = new System.Drawing.Size(140, 33);
            this.btnLimpiar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Click    += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlFormulario.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDNI, txtDNI, lblNombre, txtNombre,
                lblApellido, txtApellido, lblTelefono, txtTelefono,
                btnRegistrar, btnEditar, btnEliminar, btnLimpiar });

            // Panel Búsqueda
            this.pnlBuscar.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlBuscar.Location  = new System.Drawing.Point(15, 238);
            this.pnlBuscar.Size      = new System.Drawing.Size(730, 38);
            this.lblBuscar.Text     = "Buscar:";
            this.lblBuscar.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(5, 10);
            this.lblBuscar.AutoSize = true;
            this.txtBuscar.Location        = new System.Drawing.Point(70, 7);
            this.txtBuscar.Size            = new System.Drawing.Size(300, 25);
            this.txtBuscar.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.BorderStyle     = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.PlaceholderText = "Buscar por DNI, nombre o apellido...";
            this.txtBuscar.TextChanged    += new System.EventHandler(this.txtBuscar_TextChanged);
            this.lblSeleccionado.Text      = "Ningún registro seleccionado";
            this.lblSeleccionado.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSeleccionado.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblSeleccionado.Location  = new System.Drawing.Point(390, 12);
            this.lblSeleccionado.AutoSize  = true;
            this.pnlBuscar.Controls.AddRange(new System.Windows.Forms.Control[] { lblBuscar, txtBuscar, lblSeleccionado });

            // DataGridView
            this.dgv.Location            = new System.Drawing.Point(15, 286);
            this.dgv.Size                = new System.Drawing.Size(730, 260);
            this.dgv.AllowUserToAddRows  = false;
            this.dgv.ReadOnly            = true;
            this.dgv.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgv.RowHeadersVisible   = false;
            this.dgv.CellClick          += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);

            // Form
            this.ClientSize      = new System.Drawing.Size(760, 562);
            this.BackColor       = System.Drawing.Color.FromArgb(236, 240, 241);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Gestión de Usuarios";
            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlHeader, pnlFormulario, pnlBuscar, dgv });
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader, pnlFormulario, pnlBuscar;
        private System.Windows.Forms.Label          lblTitulo, lblSubtitulo, lblDNI, lblNombre, lblApellido, lblTelefono, lblBuscar, lblSeleccionado;
        private System.Windows.Forms.TextBox        txtDNI, txtNombre, txtApellido, txtTelefono, txtBuscar;
        private System.Windows.Forms.Button         btnRegistrar, btnEditar, btnEliminar, btnLimpiar;
        private System.Windows.Forms.DataGridView   dgv;
    }
}
