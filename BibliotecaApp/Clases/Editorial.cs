using System;

namespace BibliotecaApp.Clases
{
    internal class Editorial
    {
        public int EditorialID { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        private readonly EditorialRepositorio repositorio;

        public Editorial(string nombre)
        {
            this.Nombre   = nombre;
            this.Estado   = 1;
            repositorio   = new EditorialRepositorio();
        }

        public bool Registrar()  => repositorio.Insertar(this);
        public bool Actualizar() => repositorio.Actualizar(this);
        public bool Eliminar()   => repositorio.Eliminar(this);
    }
}
