using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormCategorias : Form
    {
        private CategoriaRepositorio repositorio = new CategoriaRepositorio();
        private int selectedID = 0;

        public FormCategorias() { InitializeComponent(); }

        private void FormCategorias_Load(object sender, EventArgs e) { Estilos.AplicarEstiloGrid(dgv); Cargar(); }

        private void Cargar() { dgv.DataSource = repositorio.ObtenerTodos(); }

        private void Limpiar() { txtNombre.Clear(); selectedID = 0; lblSeleccionado.Text = "Ningún registro seleccionado"; }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Ingrese el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Categoria c = new Categoria(txtNombre.Text.Trim());
            if (c.Registrar()) { MessageBox.Show("✅ Categoría registrada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selectedID == 0) { MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Categoria c = new Categoria(txtNombre.Text.Trim()); c.CategoriaID = selectedID;
            if (c.Actualizar()) { MessageBox.Show("✅ Categoría actualizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedID == 0) { MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar '{txtNombre.Text}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Categoria c = new Categoria(""); c.CategoriaID = selectedID;
                if (c.Eliminar()) { MessageBox.Show("✅ Categoría eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
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
                selectedID = Convert.ToInt32(fila.Cells["categoriaID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                lblSeleccionado.Text = $"Seleccionado: {txtNombre.Text}";
            }
        }
    }
}
