using System.Net;
using Templates.PlainAdmin.Data;

namespace Templates.PlainAdmin.Services;

public class AboutsServices
{
    public HttpClient _httpClient;
    public ILogger<AboutsServices> _logger;
    string _path = "/abouts";

    /// <summary>
    /// Classe responsavel por gerenciar o objecto na Base de dados
    /// </summary>
    /// <param name="httpClient">Cliente HTTP</param>
    /// <param name="logger">Registros em log</param>
    public AboutsServices(HttpClient httpClient, ILogger<AboutsServices> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Cadastrar um objecto na base de dados
    /// </summary>
    /// <param name="model">Objecto a ser salvo</param>
    /// <returns>Verdareiro se for salvo, falso caso não</returns>
    public async Task<bool> PostData(AboutItem model)
    {
        var result = await _httpClient.PostAsJsonAsync<AboutItem>(_path, model);
        return result.StatusCode == HttpStatusCode.Created ? true : false;
    }

    /// <summary>
    /// Editar um objecto na base de dados.
    /// </summary>
    /// <param name="model">Objecto a ser editado</param>
    /// <returns>Verdareiro se for editado, falso caso não</returns>
    public async Task<bool> PutData(AboutItem model)
    {
        var result = await _httpClient.PutAsJsonAsync<AboutItem>($"{_path}/{model.Id}", model);
        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }

    /// <summary>
    /// Deletar Objecto na Base de Dados
    /// </summary>
    /// <param name="model">Objecto a ser deletado</param>
    /// <returns>Verdareiro se for delatado, falso caso não</returns>
    public async Task<bool> DeleteData(AboutItem model)
    {
        var result = await _httpClient.DeleteAsync($"{_path}/{model.Id}");
        return result.StatusCode == HttpStatusCode.NoContent ? true : false;
    }

    /// <summary>
    /// Retorna um objecto na base de dados pelo ID
    /// </summary>
    /// <param name="id">ID do Objecto</param>
    /// <returns>Retorna o objecto</returns>
    public async Task<AboutItem> GetDataById(int id) => await _httpClient.GetFromJsonAsync<AboutItem>($"{_path}/{id}");

    /// <summary>
    /// Retorna todos intens na tabela
    /// </summary>
    /// <returns>Lista dos elementos na base de dados</returns>
    public async Task<List<AboutItem>> GetAllData() => await _httpClient.GetFromJsonAsync<List<AboutItem>>(_path);
}
