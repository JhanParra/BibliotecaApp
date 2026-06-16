namespace BibliotecaApp
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblSistema = new Label();
            lblSecMant = new Label();
            btnAutores = new Button();
            btnCategorias = new Button();
            btnEditoriales = new Button();
            btnLibros = new Button();
            btnUsuarios = new Button();
            lblSecTrans = new Label();
            btnPrestamos = new Button();
            btnDevoluciones = new Button();
            lblSecRep = new Label();
            btnReportes = new Button();
            btnSalir = new Button();
            pnlContenido = new Panel();
            pnlHeader = new Panel();
            lblHeaderTitulo = new Label();
            lblHeaderSub = new Label();
            pnlAlerta = new Panel();
            lblAlerta = new Label();
            pnlCard1 = new Panel();
            lblCard1Titulo = new Label();
            lblTotalLibros = new Label();
            pnlCard2 = new Panel();
            lblCard2Titulo = new Label();
            lblTotalUsuarios = new Label();
            pnlCard3 = new Panel();
            lblCard3Titulo = new Label();
            lblPrestamosActivos = new Label();
            pnlCard4 = new Panel();
            lblCard4Titulo = new Label();
            lblPrestamosVencidos = new Label();
            pnlCard5 = new Panel();
            lblCard5Titulo = new Label();
            lblMultasRecaudadas = new Label();
            pnlSidebar.SuspendLayout();
            pnlContenido.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlAlerta.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlCard5.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(26, 82, 118);
            pnlSidebar.Controls.Add(lblSistema);
            pnlSidebar.Controls.Add(lblSecMant);
            pnlSidebar.Controls.Add(btnAutores);
            pnlSidebar.Controls.Add(btnCategorias);
            pnlSidebar.Controls.Add(btnEditoriales);
            pnlSidebar.Controls.Add(btnLibros);
            pnlSidebar.Controls.Add(btnUsuarios);
            pnlSidebar.Controls.Add(lblSecTrans);
            pnlSidebar.Controls.Add(btnPrestamos);
            pnlSidebar.Controls.Add(btnDevoluciones);
            pnlSidebar.Controls.Add(lblSecRep);
            pnlSidebar.Controls.Add(btnReportes);
            pnlSidebar.Controls.Add(btnSalir);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 592);
            pnlSidebar.TabIndex = 1;
            // 
            // lblSistema
            // 
            lblSistema.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSistema.ForeColor = Color.White;
            lblSistema.Location = new Point(0, 25);
            lblSistema.Name = "lblSistema";
            lblSistema.Size = new Size(220, 32);
            lblSistema.TabIndex = 0;
            lblSistema.Text = "BIBLIOTECA";
            lblSistema.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSecMant
            // 
            lblSecMant.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblSecMant.ForeColor = Color.FromArgb(174, 214, 241);
            lblSecMant.Location = new Point(15, 72);
            lblSecMant.Name = "lblSecMant";
            lblSecMant.Size = new Size(190, 16);
            lblSecMant.TabIndex = 1;
            lblSecMant.Text = "MANTENIMIENTOS";
            // 
            // btnAutores
            // 
            btnAutores.BackColor = Color.Transparent;
            btnAutores.Cursor = Cursors.Hand;
            btnAutores.FlatAppearance.BorderSize = 0;
            btnAutores.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnAutores.FlatStyle = FlatStyle.Flat;
            btnAutores.Font = new Font("Segoe UI", 9.5F);
            btnAutores.ForeColor = Color.White;
            btnAutores.Location = new Point(0, 92);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(220, 38);
            btnAutores.TabIndex = 2;
            btnAutores.Text = "  Autores";
            btnAutores.TextAlign = ContentAlignment.MiddleLeft;
            btnAutores.UseVisualStyleBackColor = false;
            btnAutores.Click += btnAutores_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.Transparent;
            btnCategorias.Cursor = Cursors.Hand;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 9.5F);
            btnCategorias.ForeColor = Color.White;
            btnCategorias.Location = new Point(0, 132);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(220, 38);
            btnCategorias.TabIndex = 3;
            btnCategorias.Text = "  Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnEditoriales
            // 
            btnEditoriales.BackColor = Color.Transparent;
            btnEditoriales.Cursor = Cursors.Hand;
            btnEditoriales.FlatAppearance.BorderSize = 0;
            btnEditoriales.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnEditoriales.FlatStyle = FlatStyle.Flat;
            btnEditoriales.Font = new Font("Segoe UI", 9.5F);
            btnEditoriales.ForeColor = Color.White;
            btnEditoriales.Location = new Point(0, 172);
            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Size = new Size(220, 38);
            btnEditoriales.TabIndex = 4;
            btnEditoriales.Text = "  Editoriales";
            btnEditoriales.TextAlign = ContentAlignment.MiddleLeft;
            btnEditoriales.UseVisualStyleBackColor = false;
            btnEditoriales.Click += btnEditoriales_Click;
            // 
            // btnLibros
            // 
            btnLibros.BackColor = Color.Transparent;
            btnLibros.Cursor = Cursors.Hand;
            btnLibros.FlatAppearance.BorderSize = 0;
            btnLibros.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnLibros.FlatStyle = FlatStyle.Flat;
            btnLibros.Font = new Font("Segoe UI", 9.5F);
            btnLibros.ForeColor = Color.White;
            btnLibros.Location = new Point(0, 212);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(220, 38);
            btnLibros.TabIndex = 5;
            btnLibros.Text = "  Libros";
            btnLibros.TextAlign = ContentAlignment.MiddleLeft;
            btnLibros.UseVisualStyleBackColor = false;
            btnLibros.Click += btnLibros_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.Transparent;
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 9.5F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 252);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(220, 38);
            btnUsuarios.TabIndex = 6;
            btnUsuarios.Text = "  Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // lblSecTrans
            // 
            lblSecTrans.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblSecTrans.ForeColor = Color.FromArgb(174, 214, 241);
            lblSecTrans.Location = new Point(15, 302);
            lblSecTrans.Name = "lblSecTrans";
            lblSecTrans.Size = new Size(190, 16);
            lblSecTrans.TabIndex = 7;
            lblSecTrans.Text = "TRANSACCIONES";
            // 
            // btnPrestamos
            // 
            btnPrestamos.BackColor = Color.Transparent;
            btnPrestamos.Cursor = Cursors.Hand;
            btnPrestamos.FlatAppearance.BorderSize = 0;
            btnPrestamos.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnPrestamos.FlatStyle = FlatStyle.Flat;
            btnPrestamos.Font = new Font("Segoe UI", 9.5F);
            btnPrestamos.ForeColor = Color.White;
            btnPrestamos.Location = new Point(0, 322);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(220, 38);
            btnPrestamos.TabIndex = 8;
            btnPrestamos.Text = "  Préstamos";
            btnPrestamos.TextAlign = ContentAlignment.MiddleLeft;
            btnPrestamos.UseVisualStyleBackColor = false;
            btnPrestamos.Click += btnPrestamos_Click;
            // 
            // btnDevoluciones
            // 
            btnDevoluciones.BackColor = Color.Transparent;
            btnDevoluciones.Cursor = Cursors.Hand;
            btnDevoluciones.FlatAppearance.BorderSize = 0;
            btnDevoluciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnDevoluciones.FlatStyle = FlatStyle.Flat;
            btnDevoluciones.Font = new Font("Segoe UI", 9.5F);
            btnDevoluciones.ForeColor = Color.White;
            btnDevoluciones.Location = new Point(0, 362);
            btnDevoluciones.Name = "btnDevoluciones";
            btnDevoluciones.Size = new Size(220, 38);
            btnDevoluciones.TabIndex = 9;
            btnDevoluciones.Text = "  Devoluciones";
            btnDevoluciones.TextAlign = ContentAlignment.MiddleLeft;
            btnDevoluciones.UseVisualStyleBackColor = false;
            btnDevoluciones.Click += btnDevoluciones_Click;
            // 
            // lblSecRep
            // 
            lblSecRep.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblSecRep.ForeColor = Color.FromArgb(174, 214, 241);
            lblSecRep.Location = new Point(15, 412);
            lblSecRep.Name = "lblSecRep";
            lblSecRep.Size = new Size(190, 16);
            lblSecRep.TabIndex = 10;
            lblSecRep.Text = "REPORTES";
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.Transparent;
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 9.5F);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(0, 432);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(220, 38);
            btnReportes.TabIndex = 11;
            btnReportes.Text = "  Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(192, 57, 43);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(0, 547);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(220, 45);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "  Salir del Sistema";
            btnSalir.TextAlign = ContentAlignment.MiddleLeft;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.FromArgb(236, 240, 241);
            pnlContenido.Controls.Add(pnlHeader);
            pnlContenido.Controls.Add(pnlAlerta);
            pnlContenido.Controls.Add(pnlCard1);
            pnlContenido.Controls.Add(pnlCard2);
            pnlContenido.Controls.Add(pnlCard3);
            pnlContenido.Controls.Add(pnlCard4);
            pnlContenido.Controls.Add(pnlCard5);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(220, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(838, 592);
            pnlContenido.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblHeaderTitulo);
            pnlHeader.Controls.Add(lblHeaderSub);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(838, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitulo
            // 
            lblHeaderTitulo.AutoSize = true;
            lblHeaderTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitulo.ForeColor = Color.FromArgb(26, 82, 118);
            lblHeaderTitulo.Location = new Point(25, 10);
            lblHeaderTitulo.Name = "lblHeaderTitulo";
            lblHeaderTitulo.Size = new Size(184, 30);
            lblHeaderTitulo.TabIndex = 0;
            lblHeaderTitulo.Text = "Panel de Control";
            // 
            // lblHeaderSub
            // 
            lblHeaderSub.AutoSize = true;
            lblHeaderSub.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSub.ForeColor = Color.Gray;
            lblHeaderSub.Location = new Point(25, 42);
            lblHeaderSub.Name = "lblHeaderSub";
            lblHeaderSub.Size = new Size(280, 17);
            lblHeaderSub.TabIndex = 1;
            lblHeaderSub.Text = "Bienvenido al Sistema de Gestión de Biblioteca";
            // 
            // pnlAlerta
            // 
            pnlAlerta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAlerta.BackColor = Color.FromArgb(253, 237, 236);
            pnlAlerta.Controls.Add(lblAlerta);
            pnlAlerta.Location = new Point(20, 85);
            pnlAlerta.Name = "pnlAlerta";
            pnlAlerta.Size = new Size(1538, 32);
            pnlAlerta.TabIndex = 1;
            pnlAlerta.Visible = false;
            // 
            // lblAlerta
            // 
            lblAlerta.AutoSize = true;
            lblAlerta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAlerta.ForeColor = Color.FromArgb(192, 57, 43);
            lblAlerta.Location = new Point(10, 7);
            lblAlerta.Name = "lblAlerta";
            lblAlerta.Size = new Size(0, 15);
            lblAlerta.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.FromArgb(41, 128, 185);
            pnlCard1.Controls.Add(lblCard1Titulo);
            pnlCard1.Controls.Add(lblTotalLibros);
            pnlCard1.Location = new Point(20, 135);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(150, 100);
            pnlCard1.TabIndex = 2;
            // 
            // lblCard1Titulo
            // 
            lblCard1Titulo.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblCard1Titulo.ForeColor = Color.FromArgb(210, 230, 250);
            lblCard1Titulo.Location = new Point(8, 10);
            lblCard1Titulo.Name = "lblCard1Titulo";
            lblCard1Titulo.Size = new Size(134, 20);
            lblCard1Titulo.TabIndex = 0;
            lblCard1Titulo.Text = "TOTAL LIBROS";
            // 
            // lblTotalLibros
            // 
            lblTotalLibros.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalLibros.ForeColor = Color.White;
            lblTotalLibros.Location = new Point(8, 32);
            lblTotalLibros.Name = "lblTotalLibros";
            lblTotalLibros.Size = new Size(134, 55);
            lblTotalLibros.TabIndex = 1;
            lblTotalLibros.Text = "0";
            lblTotalLibros.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.FromArgb(39, 174, 96);
            pnlCard2.Controls.Add(lblCard2Titulo);
            pnlCard2.Controls.Add(lblTotalUsuarios);
            pnlCard2.Location = new Point(185, 135);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(150, 100);
            pnlCard2.TabIndex = 3;
            // 
            // lblCard2Titulo
            // 
            lblCard2Titulo.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblCard2Titulo.ForeColor = Color.FromArgb(210, 240, 220);
            lblCard2Titulo.Location = new Point(8, 10);
            lblCard2Titulo.Name = "lblCard2Titulo";
            lblCard2Titulo.Size = new Size(134, 20);
            lblCard2Titulo.TabIndex = 0;
            lblCard2Titulo.Text = "USUARIOS ACTIVOS";
            // 
            // lblTotalUsuarios
            // 
            lblTotalUsuarios.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalUsuarios.ForeColor = Color.White;
            lblTotalUsuarios.Location = new Point(8, 32);
            lblTotalUsuarios.Name = "lblTotalUsuarios";
            lblTotalUsuarios.Size = new Size(134, 55);
            lblTotalUsuarios.TabIndex = 1;
            lblTotalUsuarios.Text = "0";
            lblTotalUsuarios.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.FromArgb(243, 156, 18);
            pnlCard3.Controls.Add(lblCard3Titulo);
            pnlCard3.Controls.Add(lblPrestamosActivos);
            pnlCard3.Location = new Point(350, 135);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(150, 100);
            pnlCard3.TabIndex = 4;
            // 
            // lblCard3Titulo
            // 
            lblCard3Titulo.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblCard3Titulo.ForeColor = Color.FromArgb(250, 230, 200);
            lblCard3Titulo.Location = new Point(8, 10);
            lblCard3Titulo.Name = "lblCard3Titulo";
            lblCard3Titulo.Size = new Size(134, 20);
            lblCard3Titulo.TabIndex = 0;
            lblCard3Titulo.Text = "PRÉSTAMOS ACTIVOS";
            // 
            // lblPrestamosActivos
            // 
            lblPrestamosActivos.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPrestamosActivos.ForeColor = Color.White;
            lblPrestamosActivos.Location = new Point(8, 32);
            lblPrestamosActivos.Name = "lblPrestamosActivos";
            lblPrestamosActivos.Size = new Size(134, 55);
            lblPrestamosActivos.TabIndex = 1;
            lblPrestamosActivos.Text = "0";
            lblPrestamosActivos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.FromArgb(192, 57, 43);
            pnlCard4.Controls.Add(lblCard4Titulo);
            pnlCard4.Controls.Add(lblPrestamosVencidos);
            pnlCard4.Location = new Point(515, 135);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(150, 100);
            pnlCard4.TabIndex = 5;
            // 
            // lblCard4Titulo
            // 
            lblCard4Titulo.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblCard4Titulo.ForeColor = Color.FromArgb(250, 210, 200);
            lblCard4Titulo.Location = new Point(8, 10);
            lblCard4Titulo.Name = "lblCard4Titulo";
            lblCard4Titulo.Size = new Size(134, 20);
            lblCard4Titulo.TabIndex = 0;
            lblCard4Titulo.Text = "PRÉSTAMOS VENCIDOS";
            // 
            // lblPrestamosVencidos
            // 
            lblPrestamosVencidos.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPrestamosVencidos.ForeColor = Color.White;
            lblPrestamosVencidos.Location = new Point(8, 32);
            lblPrestamosVencidos.Name = "lblPrestamosVencidos";
            lblPrestamosVencidos.Size = new Size(134, 55);
            lblPrestamosVencidos.TabIndex = 1;
            lblPrestamosVencidos.Text = "0";
            lblPrestamosVencidos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard5
            // 
            pnlCard5.BackColor = Color.FromArgb(142, 68, 173);
            pnlCard5.Controls.Add(lblCard5Titulo);
            pnlCard5.Controls.Add(lblMultasRecaudadas);
            pnlCard5.Location = new Point(680, 135);
            pnlCard5.Name = "pnlCard5";
            pnlCard5.Size = new Size(150, 100);
            pnlCard5.TabIndex = 6;
            // 
            // lblCard5Titulo
            // 
            lblCard5Titulo.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblCard5Titulo.ForeColor = Color.FromArgb(230, 210, 240);
            lblCard5Titulo.Location = new Point(8, 10);
            lblCard5Titulo.Name = "lblCard5Titulo";
            lblCard5Titulo.Size = new Size(134, 20);
            lblCard5Titulo.TabIndex = 0;
            lblCard5Titulo.Text = "MULTAS RECAUDADAS";
            // 
            // lblMultasRecaudadas
            // 
            lblMultasRecaudadas.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblMultasRecaudadas.ForeColor = Color.White;
            lblMultasRecaudadas.Location = new Point(8, 32);
            lblMultasRecaudadas.Name = "lblMultasRecaudadas";
            lblMultasRecaudadas.Size = new Size(134, 55);
            lblMultasRecaudadas.TabIndex = 1;
            lblMultasRecaudadas.Text = "S/ 0";
            lblMultasRecaudadas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMenu
            // 
            BackColor = Color.FromArgb(26, 82, 118);
            ClientSize = new Size(1058, 592);
            Controls.Add(pnlContenido);
            Controls.Add(pnlSidebar);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Biblioteca \"Lectura Veloz\"";
            Load += FormMenu_Load;
            pnlSidebar.ResumeLayout(false);
            pnlContenido.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlAlerta.ResumeLayout(false);
            pnlAlerta.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlCard5.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel  pnlSidebar, pnlContenido, pnlHeader, pnlAlerta;
        private System.Windows.Forms.Panel  pnlCard1, pnlCard2, pnlCard3, pnlCard4, pnlCard5;
        private System.Windows.Forms.Label  lblSistema, lblSecMant, lblSecTrans, lblSecRep;
        private System.Windows.Forms.Label  lblHeaderTitulo, lblHeaderSub, lblAlerta;
        private System.Windows.Forms.Label  lblCard1Titulo, lblTotalLibros;
        private System.Windows.Forms.Label  lblCard2Titulo, lblTotalUsuarios;
        private System.Windows.Forms.Label  lblCard3Titulo, lblPrestamosActivos;
        private System.Windows.Forms.Label  lblCard4Titulo, lblPrestamosVencidos;
        private System.Windows.Forms.Label  lblCard5Titulo, lblMultasRecaudadas;
        private System.Windows.Forms.Button btnAutores, btnCategorias, btnEditoriales, btnLibros, btnUsuarios;
        private System.Windows.Forms.Button btnPrestamos, btnDevoluciones, btnReportes, btnSalir;
    }
}
