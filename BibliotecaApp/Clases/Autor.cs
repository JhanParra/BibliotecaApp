using System;

namespace BibliotecaApp.Clases
{
    internal class Autor
    {
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Estado { get; set; }

        private readonly AutorRepositorio repositorio;

        public Autor(string nombre, string apellido)
        {
            this.Nombre   = nombre;
            this.Apellido = apellido;
            this.Estado   = 1;
            repositorio   = new AutorRepositorio();
        }

        public bool Registrar()  => repositorio.Insertar(this);
        public bool Actualizar() => repositorio.Actualizar(this);
        public bool Eliminar()   => repositorio.Eliminar(this);
    }
}
