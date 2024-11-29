namespace Cliente.Data.Model
{
    public class FormularioModel
    {
        public int Id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public DateTime fechaCreacion { get; set; } = DateTime.Now;
        public DateTime fechaVencimiento { get; set; } = DateTime.Now;
        public string completado { get; set; } = "En Proceso"; // Valor predeterminado
        public int prioridad { get; set; }
        public string etiqueta { get; set; } = "Primero";
    }
}
