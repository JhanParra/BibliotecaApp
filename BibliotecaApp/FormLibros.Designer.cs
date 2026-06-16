namespace BibliotecaApp
{
    partial class FormLibros
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlFormulario = new Panel();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblTituloL = new Label();
            txtTitulo = new TextBox();
            lblAutor = new Label();
            cmbAutor = new ComboBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblEditorial = new Label();
            cmbEditorial = new ComboBox();
            lblStock = new Label();
            txtStock = new TextBox();
            btnRegistrar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            pnlBuscar = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblSeleccionado = new Label();
            dgv = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 82, 118);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(880, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(192, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE LIBROS";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 8.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(174, 214, 241);
            lblSubtitulo.Location = new Point(20, 38);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(228, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Administre el catálogo completo de libros";
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.Controls.Add(lblISBN);
            pnlFormulario.Controls.Add(txtISBN);
            pnlFormulario.Controls.Add(lblTituloL);
            pnlFormulario.Controls.Add(txtTitulo);
            pnlFormulario.Controls.Add(lblAutor);
            pnlFormulario.Controls.Add(cmbAutor);
            pnlFormulario.Controls.Add(lblCategoria);
            pnlFormulario.Controls.Add(cmbCategoria);
            pnlFormulario.Controls.Add(lblEditorial);
            pnlFormulario.Controls.Add(cmbEditorial);
            pnlFormulario.Controls.Add(lblStock);
            pnlFormulario.Controls.Add(txtStock);
            pnlFormulario.Controls.Add(btnRegistrar);
            pnlFormulario.Controls.Add(btnEditar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Location = new Point(15, 80);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(850, 178);
            pnlFormulario.TabIndex = 1;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblISBN.Location = new Point(15, 18);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(38, 15);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.BorderStyle = BorderStyle.FixedSingle;
            txtISBN.Font = new Font("Segoe UI", 9F);
            txtISBN.Location = new Point(110, 15);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(220, 23);
            txtISBN.TabIndex = 1;
            // 
            // lblTituloL
            // 
            lblTituloL.AutoSize = true;
            lblTituloL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloL.Location = new Point(15, 50);
            lblTituloL.Name = "lblTituloL";
            lblTituloL.Size = new Size(42, 15);
            lblTituloL.TabIndex = 2;
            lblTituloL.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.BorderStyle = BorderStyle.FixedSingle;
            txtTitulo.Font = new Font("Segoe UI", 9F);
            txtTitulo.Location = new Point(110, 47);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(220, 23);
            txtTitulo.TabIndex = 3;
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAutor.Location = new Point(15, 82);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(42, 15);
            lblAutor.TabIndex = 4;
            lblAutor.Text = "Autor:";
            // 
            // cmbAutor
            // 
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutor.FlatStyle = FlatStyle.Flat;
            cmbAutor.Font = new Font("Segoe UI", 9F);
            cmbAutor.Location = new Point(110, 79);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(220, 23);
            cmbAutor.TabIndex = 5;
            cmbAutor.SelectedIndexChanged += cmbAutor_SelectedIndexChanged;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoria.Location = new Point(15, 114);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(63, 15);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Segoe UI", 9F);
            cmbCategoria.Location = new Point(110, 111);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(220, 23);
            cmbCategoria.TabIndex = 7;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEditorial.Location = new Point(15, 146);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(55, 15);
            lblEditorial.TabIndex = 8;
            lblEditorial.Text = "Editorial:";
            // 
            // cmbEditorial
            // 
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.FlatStyle = FlatStyle.Flat;
            cmbEditorial.Font = new Font("Segoe UI", 9F);
            cmbEditorial.Location = new Point(110, 143);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(220, 23);
            cmbEditorial.TabIndex = 9;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStock.Location = new Point(350, 18);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(42, 15);
            lblStock.TabIndex = 10;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Font = new Font("Segoe UI", 9F);
            txtStock.Location = new Point(420, 15);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(70, 23);
            txtStock.TabIndex = 11;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(41, 128, 185);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(510, 15);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(155, 35);
            btnRegistrar.TabIndex = 12;
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(211, 84, 0);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(673, 15);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(155, 35);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(510, 58);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(155, 35);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(189, 195, 199);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.FromArgb(44, 62, 80);
            btnLimpiar.Location = new Point(673, 58);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 35);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // pnlBuscar
            // 
            pnlBuscar.BackColor = Color.FromArgb(236, 240, 241);
            pnlBuscar.Controls.Add(lblBuscar);
            pnlBuscar.Controls.Add(txtBuscar);
            pnlBuscar.Controls.Add(lblSeleccionado);
            pnlBuscar.Location = new Point(15, 268);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(850, 38);
            pnlBuscar.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.Location = new Point(5, 10);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(47, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.Location = new Point(70, 7);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por título, autor o ISBN...";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblSeleccionado
            // 
            lblSeleccionado.AutoSize = true;
            lblSeleccionado.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblSeleccionado.ForeColor = Color.FromArgb(41, 128, 185);
            lblSeleccionado.Location = new Point(395, 12);
            lblSeleccionado.Name = "lblSeleccionado";
            lblSeleccionado.Size = new Size(144, 13);
            lblSeleccionado.TabIndex = 2;
            lblSeleccionado.Text = "Ningún registro seleccionado";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.Location = new Point(15, 316);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(850, 260);
            dgv.TabIndex = 3;
            dgv.CellClick += dgv_CellClick;
            // 
            // FormLibros
            // 
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(880, 592);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlBuscar);
            Controls.Add(dgv);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLibros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Libros";
            Load += FormLibros_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlHeader, pnlFormulario, pnlBuscar;
        private System.Windows.Forms.Label          lblTitulo, lblSubtitulo, lblISBN, lblTituloL, lblAutor, lblCategoria, lblEditorial, lblStock, lblBuscar, lblSeleccionado;
        private System.Windows.Forms.TextBox        txtISBN, txtTitulo, txtStock, txtBuscar;
        private System.Windows.Forms.ComboBox       cmbAutor, cmbCategoria, cmbEditorial;
        private System.Windows.Forms.Button         btnRegistrar, btnEditar, btnEliminar, btnLimpiar;
        private System.Windows.Forms.DataGridView   dgv;
    }
}
