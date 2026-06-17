using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormLibros : Form
    {
        private LibroRepositorio libroRepo = new LibroRepositorio();
        private AutorRepositorio autorRepo = new AutorRepositorio();
        private CategoriaRepositorio catRepo = new CategoriaRepositorio();
        private EditorialRepositorio editRepo = new EditorialRepositorio();
        private string selectedISBN = "";

        public FormLibros() { InitializeComponent(); }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            Estilos.AplicarEstiloGrid(dgv);
            cmbAutor.DisplayMember = "Nombre"; cmbAutor.ValueMember = "autorID"; cmbAutor.DataSource = autorRepo.ObtenerTodos();
            cmbCategoria.DisplayMember = "Nombre"; cmbCategoria.ValueMember = "categoriaID"; cmbCategoria.DataSource = catRepo.ObtenerTodos();
            cmbEditorial.DisplayMember = "Nombre"; cmbEditorial.ValueMember = "editorialID"; cmbEditorial.DataSource = editRepo.ObtenerTodos();
            Cargar();
        }

        private void Cargar() { dgv.DataSource = libroRepo.ObtenerTodos(); }

        private void Limpiar()
        {
            txtISBN.Clear(); txtTitulo.Clear(); txtStock.Clear(); selectedISBN = "";
            if (cmbAutor.Items.Count > 0) cmbAutor.SelectedIndex = 0;
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbEditorial.Items.Count > 0) cmbEditorial.SelectedIndex = 0;
            lblSeleccionado.Text = "Ningún registro seleccionado";
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text) || string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
            { MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!int.TryParse(txtStock.Text, out _))
            { MessageBox.Show("El stock debe ser un número entero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            // ── Validación de ISBN duplicado ──
            if (libroRepo.ExisteISBN(txtISBN.Text))
            {
                MessageBox.Show(
                    $"⚠ Ya existe un libro registrado con el ISBN '{txtISBN.Text.Trim()}'.\n\n" +
                    "No se permiten libros duplicados.",
                    "ISBN Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Validación de Título duplicado ──
            if (libroRepo.ExisteTitulo(txtTitulo.Text))
            {
                MessageBox.Show(
                    $"⚠ Ya existe un libro registrado con el título '{txtTitulo.Text.Trim()}'.\n\n" +
                    "No se permiten libros duplicados.",
                    "Título Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Libro l = new Libro(txtISBN.Text, txtTitulo.Text.Trim(), Convert.ToInt32(cmbAutor.SelectedValue), Convert.ToInt32(cmbCategoria.SelectedValue), Convert.ToInt32(cmbEditorial.SelectedValue), int.Parse(txtStock.Text));
            if (l.Registrar()) { MessageBox.Show("✅ Libro registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedISBN)) { MessageBox.Show("Seleccione un libro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!Validar()) return;

            // ── Validación de ISBN duplicado (excluyendo el propio registro) ──
            if (libroRepo.ExisteISBN(txtISBN.Text, selectedISBN))
            {
                MessageBox.Show(
                    $"⚠ Ya existe OTRO libro con el ISBN '{txtISBN.Text.Trim()}'.\n\n" +
                    "No se permiten libros duplicados.",
                    "ISBN Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Validación de Título duplicado (excluyendo el propio registro) ──
            if (libroRepo.ExisteTitulo(txtTitulo.Text, selectedISBN))
            {
                MessageBox.Show(
                    $"⚠ Ya existe OTRO libro con el título '{txtTitulo.Text.Trim()}'.\n\n" +
                    "No se permiten libros duplicados.",
                    "Título Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Libro l = new Libro(selectedISBN, txtTitulo.Text.Trim(), Convert.ToInt32(cmbAutor.SelectedValue), Convert.ToInt32(cmbCategoria.SelectedValue), Convert.ToInt32(cmbEditorial.SelectedValue), int.Parse(txtStock.Text));
            if (l.Actualizar()) { MessageBox.Show("✅ Libro actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedISBN)) { MessageBox.Show("Seleccione un libro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar libro '{txtTitulo.Text}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Libro l = new Libro(selectedISBN, "", 0, 0, 0, 0);
                if (l.Eliminar()) { MessageBox.Show("✅ Libro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
                else MessageBox.Show("Error al eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro)) { dgv.DataSource = libroRepo.ObtenerTodos(); return; }

            DataTable todos = libroRepo.ObtenerTodos();
            DataTable filtrado = todos.Clone();
            foreach (DataRow row in todos.Rows)
                if (row["ISBN"].ToString().ToLower().Contains(filtro) ||
                    row["Titulo"].ToString().ToLower().Contains(filtro) ||
                    row["Autor"].ToString().ToLower().Contains(filtro))
                    filtrado.ImportRow(row);
            dgv.DataSource = filtrado;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                selectedISBN = fila.Cells["ISBN"].Value?.ToString();
                txtISBN.Text = selectedISBN;
                txtTitulo.Text = fila.Cells["Titulo"].Value?.ToString();
                txtStock.Text = fila.Cells["Stock"].Value?.ToString();
                lblSeleccionado.Text = $"Seleccionado: {txtTitulo.Text}";
            }
        }

        private void cmbAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
