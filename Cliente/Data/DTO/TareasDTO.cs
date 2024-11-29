namespace CLiente.Data.DTO
{
    public class TareasDTO
    {  
            public int ID { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; } // Corresponde a TEXT
            public DateTime FechaCreacion { get; set; } // Corresponde a DATE
            public DateTime FechaVencimiento { get; set; } // Nullable para fechas opcionales
            public bool Completada { get; set; } = false; // Valor por defecto
            public PrioridadNivel Prioridad { get; set; } = PrioridadNivel.Media; // Valor por defecto usando ENUM
            public string Etiqueta { get; set; }
        }

        public enum PrioridadNivel
        {
            Alta,
            Media,
            Baja
        }
    }

