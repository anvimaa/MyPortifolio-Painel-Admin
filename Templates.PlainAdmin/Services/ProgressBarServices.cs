using System.Net;
using Templates.PlainAdmin.Data;

namespace Templates.PlainAdmin.Services;

public class ProgressBarServices
{
    public HttpClient _httpClient;
    public ILogger<ProgressBarServices> _logger;
    string _path = "/progressbars";

    /// <summary>
    /// Classe responsavel por gerenciar o objecto na Base de dados
    /// </summary>
    /// <param name="httpClient">Cliente HTTP</param>
    /// <param name="logger">Registros em log</param>
    public ProgressBarServices(HttpClient httpClient, ILogger<ProgressBarServices> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Cadastrar um objecto na base de dados
    /// </summary>
    /// <param name="model">Objecto a ser salvo</param>
    /// <returns>Verdareiro se for salvo, falso caso não</returns>
    public async Task<bool> PostData(ProgressBar model)
    {
        var result = await _httpClient.PostAsJsonAsync<ProgressBar>(_path, model);
        return result.StatusCode == HttpStatusCode.Created ? true : false;
    }

    /// <summary>
    /// Editar um objecto na base de dados.
    /// </summary>
    /// <param name="model">Objecto a ser editado</param>
    /// <returns>Verdareiro se for editado, falso caso não</returns>
    public async Task<bool> PutData(ProgressBar model)
    {
        var result = await _httpClient.PutAsJsonAsync<ProgressBar>($"{_path}/{model.Id}", model);
        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }

    /// <summary>
    /// Deletar Objecto na Base de Dados
    /// </summary>
    /// <param name="model">Objecto a ser deletado</param>
    /// <returns>Verdareiro se for delatado, falso caso não</returns>
    public async Task<bool> DeleteData(ProgressBar model)
    {
        var result = await _httpClient.DeleteAsync($"{_path}/{model.Id}");
        return result.StatusCode == HttpStatusCode.NoContent ? true : false;
    }

    /// <summary>
    /// Retorna um objecto na base de dados pelo ID
    /// </summary>
    /// <param name="id">ID do Objecto</param>
    /// <returns>Retorna o objecto</returns>
    public async Task<ProgressBar> GetDataById(int id) => await _httpClient.GetFromJsonAsync<ProgressBar>($"{_path}/{id}");

    /// <summary>
    /// Retorna todos intens na tabela
    /// </summary>
    /// <returns>Lista dos elementos na base de dados</returns>
    public async Task<List<ProgressBar>> GetAllData() => await _httpClient.GetFromJsonAsync<List<ProgressBar>>(_path);
}
