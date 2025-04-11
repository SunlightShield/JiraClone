using System.ComponentModel.DataAnnotations.Schema; //para usar el not mapped
namespace TaskBoard.Domain.Entities
{

    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public bool Completada { get; set; } = false;

        //funcion para calcular las semanas

        [NotMapped] // <- asi se evita que entity lo agrege al SQL
        public int SemanaDelMes => CalcularSemanaDelMes(FechaCreacion);

        //asi calculamos las semanas
        private int CalcularSemanaDelMes(DateTime fecha)
        {
            var firstDay = new DateTime(fecha.Year, fecha.Month, 1);
            int offset = (int)firstDay.DayOfWeek; 
            return (int)Math.Ceiling((fecha.Day + offset) / 7.0);
        }
    }

}
