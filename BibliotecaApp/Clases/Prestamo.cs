using System;

namespace BibliotecaApp.Clases
{
    internal class Prestamo
    {
        public int PrestamoID { get; set; }
        public string DNI_Usuario { get; set; }
        public int LibroID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string Estado { get; set; }
        public decimal Multa { get; set; }

        private readonly PrestamoRepositorio repositorio;

        public Prestamo(string dniUsuario, int libroID, DateTime fechaDevolucion)
        {
            this.DNI_Usuario     = dniUsuario;
            this.LibroID         = libroID;
            this.FechaPrestamo   = DateTime.Today;
            this.FechaDevolucion = fechaDevolucion;
            this.Estado          = "Activo";
            this.Multa           = 0;
            repositorio          = new PrestamoRepositorio();
        }

        public bool Registrar() => repositorio.Insertar(this);
        public ResultadoDevolucion MarcarDevuelto() => repositorio.MarcarDevuelto(this.PrestamoID);
    }

    // Clase para retornar resultado de devolución con multa
    internal class ResultadoDevolucion
    {
        public bool Exito { get; set; }
        public decimal Multa { get; set; }
        public int DiasRetraso { get; set; }
        public string Mensaje { get; set; }
    }
}
