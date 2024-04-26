namespace Gestion_de_Turnos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Documento { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? TipoAfiliacion { get; set; }
    }
}