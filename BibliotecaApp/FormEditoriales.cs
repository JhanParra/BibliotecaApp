using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormEditoriales : Form
    {
        private EditorialRepositorio repositorio = new EditorialRepositorio();
        private int selectedID = 0;

        public FormEditoriales() { InitializeComponent(); }

        private void FormEditoriales_Load(object sender, EventArgs e) { Estilos.AplicarEstiloGrid(dgv); Cargar(); }

        private void Cargar() { dgv.DataSource = repositorio.ObtenerTodos(); }

        private void Limpiar() { txtNombre.Clear(); selectedID = 0; lblSeleccionado.Text = "Ningún registro seleccionado"; }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Ingrese el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // ── Validación de duplicado ──
            if (repositorio.Existe(txtNombre.Text))
            {
                MessageBox.Show(
                    $"⚠ Ya existe la editorial '{txtNombre.Text.Trim()}'.\n\n" +
                    "No se permiten editoriales duplicadas.",
                    "Editorial Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Editorial ed = new Editorial(txtNombre.Text.Trim());
            if (ed.Registrar()) { MessageBox.Show("✅ Editorial registrada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selectedID == 0) { MessageBox.Show("Seleccione una editorial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Ingrese el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // ── Validación de duplicado (excluyendo el propio registro) ──
            if (repositorio.Existe(txtNombre.Text, selectedID))
            {
                MessageBox.Show(
                    $"⚠ Ya existe OTRA editorial llamada '{txtNombre.Text.Trim()}'.\n\n" +
                    "No se permiten editoriales duplicadas.",
                    "Editorial Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Editorial ed = new Editorial(txtNombre.Text.Trim()); ed.EditorialID = selectedID;
            if (ed.Actualizar()) { MessageBox.Show("✅ Editorial actualizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedID == 0) { MessageBox.Show("Seleccione una editorial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar '{txtNombre.Text}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Editorial ed = new Editorial(""); ed.EditorialID = selectedID;
                if (ed.Eliminar()) { MessageBox.Show("✅ Editorial eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
                else MessageBox.Show("Error al eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro)) { dgv.DataSource = repositorio.ObtenerTodos(); return; }

            DataTable todos = repositorio.ObtenerTodos();
            DataTable filtrado = todos.Clone();
            foreach (DataRow row in todos.Rows)
                if (row["Nombre"].ToString().ToLower().Contains(filtro))
                    filtrado.ImportRow(row);
            dgv.DataSource = filtrado;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(fila.Cells["editorialID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                lblSeleccionado.Text = $"Seleccionado: {txtNombre.Text}";
            }
        }
    }
}
