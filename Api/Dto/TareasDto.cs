using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Dto
{
    public class TareasDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool Completada { get; set; } = false;
        [EnumDataType(typeof(PrioridadNivel))]
        public PrioridadNivel Prioridad { get; set; } = PrioridadNivel.Media;
        [MaxLength(50)]
        public string Etiqueta { get; set; }
    }

    public enum PrioridadNivel
    {
        Alta,
        Media,
        Baja
    }
}
