using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormMenu : Form
    {
        private PrestamoRepositorio repo = new PrestamoRepositorio();

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            ActualizarDashboard();
            CargarPanelBienvenida();
        }

        private void CargarPanelBienvenida()
        {
            //Panel principal blanco
            Panel pnlBienvenida = new Panel();
            pnlBienvenida.Location = new Point(20, 255);
            pnlBienvenida.Size = new Size(pnlContenido.Width - 40, 280);
            pnlBienvenida.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBienvenida.BackColor = Color.White;

            //Columna izquierda: Logo
            PictureBox picLogo = new PictureBox();
            picLogo.Location = new Point(20, 20);
            picLogo.Size = new Size(160, 160);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.White;

            string[] rutas = {
                System.IO.Path.Combine(Application.StartupPath, "biblioteca.jpg"),
                System.IO.Path.Combine(Application.StartupPath, "biblioteca.png"),
                System.IO.Path.Combine(Application.StartupPath, "logo.jpg"),
                System.IO.Path.Combine(Application.StartupPath, "logo.png"),
            };

            foreach (string ruta in rutas)
            {
                if (System.IO.File.Exists(ruta))
                {
                    try
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(ruta);
                        using (var ms = new System.IO.MemoryStream(bytes))
                            picLogo.Image = new Bitmap(Image.FromStream(ms));
                        break;
                    }
                    catch { }
                }
            }

            if (picLogo.Image == null)
            {
                //Si no hay imagen, mostrar emoji grande
                Label lblEmoji = new Label();
                lblEmoji.Text = "📚";
                lblEmoji.Font = new Font("Segoe UI", 52F);
                lblEmoji.Location = new Point(20, 20);
                lblEmoji.Size = new Size(160, 120);
                lblEmoji.TextAlign = ContentAlignment.MiddleCenter;
                pnlBienvenida.Controls.Add(lblEmoji);
            }
            else
            {
                pnlBienvenida.Controls.Add(picLogo);
            }

            //Columna derecha: Textos
            Label lblNombre = new Label();
            lblNombre.Text = "Biblioteca 'Lectura Veloz'";
            lblNombre.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(26, 82, 118);
            lblNombre.Location = new Point(200, 25);
            lblNombre.Size = new Size(700, 38);

            Label lblSlogan = new Label();
            lblSlogan.Text = "De Sabiduría Acelerada — Gestión integral de préstamos";
            lblSlogan.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSlogan.ForeColor = Color.Gray;
            lblSlogan.Location = new Point(200, 65);
            lblSlogan.Size = new Size(700, 25);

            //Línea separadora
            Panel pnlLinea = new Panel();
            pnlLinea.Location = new Point(200, 98);
            pnlLinea.Size = new Size(700, 2);
            pnlLinea.BackColor = Color.FromArgb(41, 128, 185);

            //Reglas del sistema en 2 columnas
            Label lblTituloReglas = new Label();
            lblTituloReglas.Text = "Reglas del sistema:";
            lblTituloReglas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloReglas.ForeColor = Color.FromArgb(44, 62, 80);
            lblTituloReglas.Location = new Point(200, 110);
            lblTituloReglas.AutoSize = true;

            string[] reglas = {
                "✅  Máximo 2 libros por usuario al mismo tiempo",
                "⏰  Multa de S/ 1.50 por cada día de retraso",
                "📦  Libros con stock menor a 3: máximo 3 días de préstamo",
                "⛔  Usuario con mora no puede realizar nuevos préstamos",
            };

            int yRegla = 132;
            foreach (string regla in reglas)
            {
                Label lbl = new Label();
                lbl.Text = regla;
                lbl.Font = new Font("Segoe UI", 9F);
                lbl.ForeColor = Color.FromArgb(44, 62, 80);
                lbl.Location = new Point(200, yRegla);
                lbl.Size = new Size(680, 22);
                pnlBienvenida.Controls.Add(lbl);
                yRegla += 26;
            }

            //Footer del panel
            Panel pnlFooter = new Panel();
            pnlFooter.Location = new Point(0, 245);
            pnlFooter.Size = new Size(pnlBienvenida.Width, 35);
            pnlFooter.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pnlFooter.BackColor = Color.FromArgb(26, 82, 118);

            Label lblFooter = new Label();
            lblFooter.Text = "  Sistema desarrollado con C# y SQL Server  |  CIBERTEC 2026";
            lblFooter.Font = new Font("Segoe UI", 8.5F);
            lblFooter.ForeColor = Color.FromArgb(174, 214, 241);
            lblFooter.Location = new Point(10, 9);
            lblFooter.AutoSize = true;
            pnlFooter.Controls.Add(lblFooter);

            pnlBienvenida.Controls.Add(lblNombre);
            pnlBienvenida.Controls.Add(lblSlogan);
            pnlBienvenida.Controls.Add(pnlLinea);
            pnlBienvenida.Controls.Add(lblTituloReglas);
            pnlBienvenida.Controls.Add(pnlFooter);

            pnlContenido.Controls.Add(pnlBienvenida);
        }

        private void ActualizarDashboard()
        {
            try
            {
                DataTable dt = repo.ObtenerEstadisticas();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTotalLibros.Text = row["TotalLibros"].ToString();
                    lblTotalUsuarios.Text = row["TotalUsuarios"].ToString();
                    lblPrestamosActivos.Text = row["PrestamosActivos"].ToString();
                    lblPrestamosVencidos.Text = row["PrestamosVencidos"].ToString();
                    lblMultasRecaudadas.Text = "S/ " + Convert.ToDecimal(row["TotalMultasRecaudadas"]).ToString("0.00");

                    int vencidos = Convert.ToInt32(row["PrestamosVencidos"]);
                    pnlAlerta.Visible = vencidos > 0;
                    lblAlerta.Text = $"⚠  Hay {vencidos} préstamo(s) vencido(s) sin devolver.";
                }
            }
            catch { }
        }

        private void AbrirForm(Form form)
        {
            form.ShowDialog();
            ActualizarDashboard();
        }

        private void btnAutores_Click(object sender, EventArgs e) => AbrirForm(new FormAutores());
        private void btnCategorias_Click(object sender, EventArgs e) => AbrirForm(new FormCategorias());
        private void btnEditoriales_Click(object sender, EventArgs e) => AbrirForm(new FormEditoriales());
        private void btnLibros_Click(object sender, EventArgs e) => AbrirForm(new FormLibros());
        private void btnUsuarios_Click(object sender, EventArgs e) => AbrirForm(new FormUsuarios());
        private void btnPrestamos_Click(object sender, EventArgs e) => AbrirForm(new FormPrestamos());
        private void btnDevoluciones_Click(object sender, EventArgs e) => AbrirForm(new FormDevoluciones());
        private void btnReportes_Click(object sender, EventArgs e) => AbrirForm(new FormReportes());

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void pnlAlerta_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
