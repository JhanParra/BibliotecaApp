using System;

namespace BibliotecaApp.Clases
{
    internal class Libro
    {
        public int LibroID { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int AutorID { get; set; }
        public int CategoriaID { get; set; }
        public int EditorialID { get; set; }
        public int Stock { get; set; }
        public int Estado { get; set; }

        private readonly LibroRepositorio repositorio;

        public Libro(string isbn, string titulo, int autorID, int categoriaID, int editorialID, int stock)
        {
            this.ISBN        = isbn;
            this.Titulo      = titulo;
            this.AutorID     = autorID;
            this.CategoriaID = categoriaID;
            this.EditorialID = editorialID;
            this.Stock       = stock;
            this.Estado      = 1;
            repositorio      = new LibroRepositorio();
        }

        public bool Registrar()  => repositorio.Insertar(this);
        public bool Actualizar() => repositorio.Actualizar(this);
        public bool Eliminar()   => repositorio.Eliminar(this);
    }
}
