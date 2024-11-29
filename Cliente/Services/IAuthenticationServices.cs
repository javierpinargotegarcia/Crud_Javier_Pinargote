using CLiente.Data.Model;

namespace CLiente.Services
{
    interface  IAuthenticationServices
    {
        Task<AuthTokenResponse> AuthenticateAsync(FormularioLogin input);
        Task<ValidationErrorResponse> RegisterAsync(FormularioRegister input);
    }
}
