using System;
using System.Windows.Forms;
using BibliotecaApp.Clases;

namespace BibliotecaApp
{
    public partial class FormUsuarios : Form
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();
        private bool modoEdicion = false;

        public FormUsuarios() { InitializeComponent(); }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            Estilos.AplicarEstiloGrid(dgv);
            Cargar();
        }

        private void Cargar() 
        { 
            dgv.DataSource = repositorio.ObtenerTodos(); 
        }

        private void Limpiar()
        {
            txtDNI.Clear(); txtNombre.Clear(); txtApellido.Clear(); txtTelefono.Clear();
            lblSeleccionado.Text = "Ningún registro seleccionado";
            modoEdicion = false;
            txtDNI.ReadOnly = false;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            { MessageBox.Show("DNI, Nombre y Apellido son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (txtDNI.Text.Length != 8)
            { MessageBox.Show("El DNI debe tener exactamente 8 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            //Validación de DNI duplicado
            if (repositorio.ExisteDNI(txtDNI.Text))
            {
                MessageBox.Show(
                    $"⚠ Ya existe un usuario registrado con el DNI '{txtDNI.Text.Trim()}'.\n\n" +
                    "No se permiten usuarios duplicados.\n" +
                    "Si desea modificar sus datos, selecciónelo de la lista y use 'Editar'.",
                    "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario u = new Usuario(txtDNI.Text, txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtTelefono.Text.Trim());
            if (u.Registrar()) { MessageBox.Show("✅ Usuario registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            //El DNI es la llave primaria no se valida duplicado en edición porque no cambia
            Usuario u = new Usuario(txtDNI.Text, txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtTelefono.Text.Trim());
            if (u.Actualizar()) { MessageBox.Show("✅ Usuario actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
            else MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text)) { MessageBox.Show("Ingrese el DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar usuario {txtNombre.Text} {txtApellido.Text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Usuario u = new Usuario(txtDNI.Text, "", "", "");
                if (u.Eliminar()) { MessageBox.Show("✅ Usuario eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar(); Cargar(); }
                else MessageBox.Show("Error al eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();

        //Búsqueda: filtra desde la fuente de datos
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                dgv.DataSource = repositorio.ObtenerTodos();
                return;
            }

            var todos = repositorio.ObtenerTodos();
            var filtrado = new System.Data.DataTable();
            filtrado = todos.Clone();

            foreach (System.Data.DataRow row in todos.Rows)
            {
                if (row["DNI"].ToString().ToLower().Contains(filtro) ||
                    row["Nombre"].ToString().ToLower().Contains(filtro) ||
                    row["Apellido"].ToString().ToLower().Contains(filtro))
                {
                    filtrado.ImportRow(row);
                }
            }

            dgv.DataSource = filtrado;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                txtDNI.Text      = fila.Cells["DNI"].Value?.ToString();
                txtNombre.Text   = fila.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
                lblSeleccionado.Text = $"Seleccionado: {txtNombre.Text} {txtApellido.Text}";

                //Bloquea el DNI al editar para que no se intente cambiar -> es la PK
                modoEdicion = true;
                txtDNI.ReadOnly = true;
            }
        }
    }
}
