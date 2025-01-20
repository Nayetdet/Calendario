using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;

namespace Calendario.Core.Services;

public class OAuthService : IOAuthService
{
    private readonly IConfiguration _configuration;

    public OAuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<CalendarService> Autenticar(CancellationToken cancellationToken)
    {
        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            clientSecrets: _configuration.GetSection("Google").Get<ClientSecrets>(),
            scopes: _configuration.GetSection("Google:Scopes").Get<IEnumerable<string>>(),
            user: "user",
            taskCancellationToken: cancellationToken
        );

        var services = new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "Teste-Integracao-Calendario"
        });
        
        services.HttpClient.DefaultRequestHeaders.Add("TimeZone", "America/Fortaleza");
        
        return services;
    }
}