using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaApp
{
    internal static class Estilos
    {
        // ── Paleta de colores ──────────────────────────────
        public static readonly Color Primario      = Color.FromArgb(26,  82,  118);  // azul oscuro
        public static readonly Color PrimarioClaro = Color.FromArgb(41,  128, 185);  // azul medio
        public static readonly Color Acento        = Color.FromArgb(23,  165, 137);  // verde azulado
        public static readonly Color Peligro       = Color.FromArgb(192, 57,  43);   // rojo
        public static readonly Color Advertencia   = Color.FromArgb(211, 84,  0);    // naranja
        public static readonly Color Fondo         = Color.FromArgb(236, 240, 241);  // gris claro
        public static readonly Color FondoPanel    = Color.FromArgb(255, 255, 255);  // blanco
        public static readonly Color TextoClaro    = Color.White;
        public static readonly Color TextoOscuro   = Color.FromArgb(44,  62,  80);   // casi negro
        public static readonly Color Borde         = Color.FromArgb(189, 195, 199);  // gris borde

        // ── Fuentes ────────────────────────────────────────
        public static readonly Font FuenteTitulo   = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo= new Font("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FuenteNormal   = new Font("Segoe UI",  9F);
        public static readonly Font FuenteBoton    = new Font("Segoe UI",  9F, FontStyle.Bold);
        public static readonly Font FuentePequena  = new Font("Segoe UI",  8F);

        // ── Aplicar estilo a botón primario ────────────────
        public static void AplicarBotonPrimario(Button btn)
        {
            btn.BackColor = PrimarioClaro;
            btn.ForeColor = TextoClaro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = FuenteBoton;
            btn.Cursor    = Cursors.Hand;
        }

        public static void AplicarBotonEditar(Button btn)
        {
            btn.BackColor = Advertencia;
            btn.ForeColor = TextoClaro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = FuenteBoton;
            btn.Cursor    = Cursors.Hand;
        }

        public static void AplicarBotonEliminar(Button btn)
        {
            btn.BackColor = Peligro;
            btn.ForeColor = TextoClaro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = FuenteBoton;
            btn.Cursor    = Cursors.Hand;
        }

        public static void AplicarBotonSecundario(Button btn)
        {
            btn.BackColor = Fondo;
            btn.ForeColor = TextoOscuro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Borde;
            btn.FlatAppearance.BorderSize  = 1;
            btn.Font      = FuenteBoton;
            btn.Cursor    = Cursors.Hand;
        }

        // ── Aplicar estilo a DataGridView ──────────────────
        public static void AplicarEstiloGrid(DataGridView dgv)
        {
            dgv.BackgroundColor         = FondoPanel;
            dgv.BorderStyle             = BorderStyle.None;
            dgv.CellBorderStyle         = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor               = Color.FromArgb(220, 220, 220);
            dgv.ColumnHeadersBorderStyle= DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Primario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoClaro;
            dgv.ColumnHeadersDefaultCellStyle.Font      = FuenteBoton;
            dgv.ColumnHeadersDefaultCellStyle.Padding   = new Padding(5, 0, 0, 0);
            dgv.ColumnHeadersHeight     = 35;
            dgv.DefaultCellStyle.BackColor    = FondoPanel;
            dgv.DefaultCellStyle.ForeColor    = TextoOscuro;
            dgv.DefaultCellStyle.Font         = FuenteNormal;
            dgv.DefaultCellStyle.SelectionBackColor = PrimarioClaro;
            dgv.DefaultCellStyle.SelectionForeColor = TextoClaro;
            dgv.DefaultCellStyle.Padding      = new Padding(5, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgv.RowHeadersVisible       = false;
            dgv.RowTemplate.Height      = 32;
            dgv.AllowUserToAddRows      = false;
            dgv.ReadOnly                = true;
            dgv.SelectionMode           = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode     = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ── Panel de encabezado azul ───────────────────────
        public static Panel CrearPanelHeader(string titulo, int width)
        {
            Panel panel = new Panel
            {
                BackColor = Primario,
                Dock      = DockStyle.Top,
                Height    = 55
            };
            Label lbl = new Label
            {
                Text      = titulo,
                Font      = FuenteTitulo,
                ForeColor = TextoClaro,
                AutoSize  = false,
                Size      = new Size(width, 55),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(lbl);
            return panel;
        }

        // ── TextBox estilizado ─────────────────────────────
        public static void AplicarEstiloTextBox(TextBox txt)
        {
            txt.Font        = FuenteNormal;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor   = FondoPanel;
            txt.ForeColor   = TextoOscuro;
        }

        // ── ComboBox estilizado ────────────────────────────
        public static void AplicarEstiloCombo(ComboBox cmb)
        {
            cmb.Font      = FuenteNormal;
            cmb.BackColor = FondoPanel;
            cmb.ForeColor = TextoOscuro;
            cmb.FlatStyle = FlatStyle.Flat;
        }
    }
}
