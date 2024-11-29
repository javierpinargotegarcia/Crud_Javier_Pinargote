using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Tareas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // AutoIncrement equivalente
        public int ID { get; set; }

        [Required]
        [MaxLength(255)] // Corresponde a VARCHAR(255)
        public string Titulo { get; set; }

        public string Descripcion { get; set; } // Corresponde a TEXT

        [Required]
        public DateTime FechaCreacion { get; set; } // Corresponde a DATE

        public DateTime? FechaVencimiento { get; set; } // Nullable para fechas opcionales

        [Required]
        public bool Completada { get; set; } = false; // Valor por defecto


        [EnumDataType(typeof(PrioridadNivel))]
        public PrioridadNivel Prioridad { get; set; } = PrioridadNivel.Media; // Valor por defecto usando ENUM

        [MaxLength(50)] // Corresponde a VARCHAR(50)
        public string Etiqueta { get; set; }
    }

    public enum PrioridadNivel
    {
        Alta,
        Media,
        Baja
    }
}

