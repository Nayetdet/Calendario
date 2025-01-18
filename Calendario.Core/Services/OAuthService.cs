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
    
    public async Task<CalendarService> Autenticar(string[] scopes)
    {
        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            clientSecrets: new ClientSecrets
            {
                ClientId = _configuration.GetValue<string>("Google:ClientId"),
                ClientSecret = _configuration.GetValue<string>("Google:ClientSecret")
            },
            scopes: scopes,
            user: "user",
            taskCancellationToken: CancellationToken.None
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