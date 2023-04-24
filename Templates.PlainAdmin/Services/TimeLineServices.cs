using System.Net;
using Templates.PlainAdmin.Data;

namespace Templates.PlainAdmin.Services;

public class TimeLineServices
{
    public HttpClient _httpClient;
    public ILogger<TimeLineServices> _logger;
    string _path = "/timelines";

    /// <summary>
    /// Classe responsavel por gerenciar o objecto na Base de dados
    /// </summary>
    /// <param name="httpClient">Cliente HTTP</param>
    /// <param name="logger">Registros em log</param>
    public TimeLineServices(HttpClient httpClient, ILogger<TimeLineServices> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Cadastrar um objecto na base de dados
    /// </summary>
    /// <param name="model">Objecto a ser salvo</param>
    /// <returns>Verdareiro se for salvo, falso caso não</returns>
    public async Task<bool> PostData(TimeLineItem model)
    {
        var result = await _httpClient.PostAsJsonAsync<TimeLineItem>(_path, model);
        return result.StatusCode == HttpStatusCode.Created ? true : false;
    }
    
    /// <summary>
    /// Editar um objecto na base de dados.
    /// </summary>
    /// <param name="model">Objecto a ser editado</param>
    /// <returns>Verdareiro se for editado, falso caso não</returns>
    public async Task<bool> PutData(TimeLineItem model)
    {
        var result = await _httpClient.PutAsJsonAsync<TimeLineItem>($"{_path}/{model.Id}", model);
        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }

    /// <summary>
    /// Deletar Objecto na Base de Dados
    /// </summary>
    /// <param name="model">Objecto a ser deletado</param>
    /// <returns>Verdareiro se for delatado, falso caso não</returns>
    public async Task<bool> DeleteData(TimeLineItem model)
    {
        var result = await _httpClient.DeleteAsync($"{_path}/{model.Id}");
        return result.StatusCode == HttpStatusCode.NoContent ? true : false;
    }

    /// <summary>
    /// Retorna um objecto na base de dados pelo ID
    /// </summary>
    /// <param name="id">ID do Objecto</param>
    /// <returns>Retorna o objecto</returns>
    public async Task<TimeLineItem> GetDataById(int id) => await _httpClient.GetFromJsonAsync<TimeLineItem>($"{_path}/{id}");

    /// <summary>
    /// Retorna todos intens na tabela
    /// </summary>
    /// <returns>Lista dos elementos na base de dados</returns>
    public async Task<List<TimeLineItem>> GetAllData() => await _httpClient.GetFromJsonAsync<List<TimeLineItem>>(_path);
}
