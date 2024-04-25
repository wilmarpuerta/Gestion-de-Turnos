namespace Gestion_de_Turnos.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string? TipoServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string? Estado { get; set; }
        public int IdUsuario { get; set; }
  
    }
}