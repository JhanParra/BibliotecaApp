using System;

namespace BibliotecaApp.Clases
{
    internal class Usuario
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }

        private readonly UsuarioRepositorio repositorio;

        public Usuario(string dni, string nombre, string apellido, string telefono)
        {
            this.DNI      = dni;
            this.Nombre   = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Estado   = 1;
            repositorio   = new UsuarioRepositorio();
        }

        public bool Registrar()  => repositorio.Insertar(this);
        public bool Actualizar() => repositorio.Actualizar(this);
        public bool Eliminar()   => repositorio.Eliminar(this);
    }
}
