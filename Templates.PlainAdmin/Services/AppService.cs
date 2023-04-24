using Templates.PlainAdmin.Data;

namespace Templates.PlainAdmin.Services;
public class AppService
{
    public HttpClient _httpClient;
    public ILogger<AppService> _logger;

    public AppService(HttpClient httpClient, ILogger<AppService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    

    public async Task<List<PortifolioItem>> GetPortifolio() => await _httpClient.GetFromJsonAsync<List<PortifolioItem>>("/portifolios");

    public async Task<List<CertificacaoItem>> GetCertificacoes() => await _httpClient.GetFromJsonAsync<List<CertificacaoItem>>("/certificacaos");

    public async Task<List<ContactItem>> GetContacts() => await _httpClient.GetFromJsonAsync<List<ContactItem>>("/contacts");

    public async Task<List<SocialItem>> GetSocials() => await _httpClient.GetFromJsonAsync<List<SocialItem>>("/socials");
}
 