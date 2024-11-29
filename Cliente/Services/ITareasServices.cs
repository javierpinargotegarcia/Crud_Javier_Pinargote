using Cliente.Data.Model;
using CLiente.Data.DTO;

namespace CLiente.Services
{
    public interface ITareasServices
    {
        Task<List<TareasDTO>> Lista();
        Task<bool> Eliminar(int id);
        Task<bool> AgregarTareas(FormularioModel data);
        Task<ResponseAPI<TareasDTO>> ActualizarTareas(FormularioModel data);
        Task<TareasDTO> ObtenerTareaPorId(int id);
    }
}
