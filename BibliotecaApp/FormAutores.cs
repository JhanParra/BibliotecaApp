using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormAutores : Form
    {
        private AutorRepositorio repositorio = new AutorRepositorio();
        private int selectedID = 0;

        public FormAutores() { InitializeComponent(); }

        private void FormAutores_Load(object sender, EventArgs e) { Estilos.AplicarEstiloGrid(dgv); Cargar(); }

        private void Cargar() { dgv.DataSource = repositorio.ObtenerTodos(); }

        private void Limpiar() { txtNombre.Clear(); txtApellido.Clear(); selectedID = 0; lblSeleccionado.Text = "Ningún registro seleccionado"; }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            { MessageBox.Show("Nombre y Apellido son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            Autor a = new Autor(txtNombre.Text.Trim(), txtApellido.Text.Trim());
            if (a.Registrar()) { MessageBox.Show("✅ Autor registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selectedID == 0) { MessageBox.Show("Seleccione un autor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!Validar()) return;
            Autor a = new Autor(txtNombre.Text.Trim(), txtApellido.Text.Trim()); a.AutorID = selectedID;
            if (a.Actualizar()) { MessageBox.Show("✅ Autor actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedID == 0) { MessageBox.Show("Seleccione un autor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar autor {txtNombre.Text} {txtApellido.Text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Autor a = new Autor("", ""); a.AutorID = selectedID;
                if (a.Eliminar()) { MessageBox.Show("✅ Autor eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
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
                if (row["Nombre"].ToString().ToLower().Contains(filtro) ||
                    row["Apellido"].ToString().ToLower().Contains(filtro))
                    filtrado.ImportRow(row);
            dgv.DataSource = filtrado;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(fila.Cells["autorID"].Value);
                txtNombre.Text   = fila.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
                lblSeleccionado.Text = $"Seleccionado: {txtNombre.Text} {txtApellido.Text}";
            }
        }
    }
}
