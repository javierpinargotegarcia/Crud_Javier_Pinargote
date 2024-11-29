using CLiente.Data.Model;
using Newtonsoft.Json;

namespace CLiente.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly HttpClient _http;

        public AuthenticationServices(HttpClient http) 
        {
            _http = http;
        }
        public async Task<AuthTokenResponse> AuthenticateAsync(FormularioLogin input)
        {
            string jsonString = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("identity/login", content);
            
            AuthTokenResponse tokenResponse = new AuthTokenResponse();
            if (!response.IsSuccessStatusCode)
            {
                tokenResponse.Status = 401;
                tokenResponse.Mensaje = "No Autorizado";
            }
            else
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                tokenResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(responseBody);
                tokenResponse.Status = 200;


            }

            return tokenResponse;

        }

        public async Task<ValidationErrorResponse> RegisterAsync(FormularioRegister input)
        {
            string jsonString = JsonConvert.SerializeObject(input);
            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("identity/register", content);
            ValidationErrorResponse errorResponse = new ValidationErrorResponse();
            if (!response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar el JSON en la clase ValidationErrorResponse
                errorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(responseBody);

                if (errorResponse != null)
                {
                    Console.WriteLine($"Error Title: {errorResponse.Title}");
                    Console.WriteLine($"Status: {errorResponse.Status}");

                    foreach (var error in errorResponse.Errors)
                    {
                        Console.WriteLine($"Error Key: {error.Key}");
                        foreach (var message in error.Value)
                        {
                            Console.WriteLine($" - {message}");
                        }
                    }
                }
            }
            else
            {
                errorResponse.Status = 200;
                Console.WriteLine("Usuario registrado exitosamente.");
                
            }

            return errorResponse;
            
        }
    }
}
