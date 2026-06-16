using System;

namespace BibliotecaApp.Clases
{
    internal class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        private readonly CategoriaRepositorio repositorio;

        public Categoria(string nombre)
        {
            this.Nombre   = nombre;
            this.Estado   = 1;
            repositorio   = new CategoriaRepositorio();
        }

        public bool Registrar()  => repositorio.Insertar(this);
        public bool Actualizar() => repositorio.Actualizar(this);
        public bool Eliminar()   => repositorio.Eliminar(this);
    }
}
