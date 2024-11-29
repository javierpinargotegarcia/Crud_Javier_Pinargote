using Cliente.Data.Model;
using CLiente.Data.DTO;
using Newtonsoft.Json;


namespace CLiente.Services
{
    public class TareasServices : ITareasServices
    {
        private readonly HttpClient _http;

        public TareasServices(HttpClient http)
        {
            _http = http;
        }
        public async Task<bool> AgregarTareas(FormularioModel data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var result = await _http.PostAsync("api/Tareas/guardar", content);
            var responseString = await result.Content.ReadAsStringAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync("api/Tareas/Eliminar/"+id);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<TareasDTO>> Lista()
        {
            List<TareasDTO> tt = new();
            var result = await _http.GetAsync("api/Tareas/lista");
            var response = result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TareasDTO>>(response.Result);
        }

        public async Task<ResponseAPI<TareasDTO>> ActualizarTareas(FormularioModel data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var result = await _http.PutAsync("api/Tareas/editar", content);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<TareasDTO>>();

            if (response == null)
            {
                throw new Exception("Error al deserializar la respuesta del servidor.");
            }

            if (!response.EsCorrecto)
            {
                throw new Exception(response.Mensaje);
            }

            return response;
        }

        public async Task<TareasDTO> ObtenerTareaPorId(int id)
        {
            var result = await _http.GetAsync($"api/Tareas/buscar/{id}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TareasDTO>(response);
        }
    }
}
