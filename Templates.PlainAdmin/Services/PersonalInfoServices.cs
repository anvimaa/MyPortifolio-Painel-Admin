using System.Net;
using Templates.PlainAdmin.Data;

namespace Templates.PlainAdmin.Services;

public class PersonalInfoServices
{
    public HttpClient _httpClient;
    public ILogger<PersonalInfoServices> _logger;
    string _path = "/personals";

    /// <summary>
    /// Classe responsavel por gerenciar o objecto na Base de dados
    /// </summary>
    /// <param name="httpClient">Cliente HTTP</param>
    /// <param name="logger">Registros em log</param>
    public PersonalInfoServices(HttpClient httpClient, ILogger<PersonalInfoServices> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Cadastrar um objecto na base de dados
    /// </summary>
    /// <param name="personalInfo">Objecto a ser salvo</param>
    /// <returns>Verdareiro se for salvo, falso caso não</returns>
    public async Task<bool> PostData(PersonalInfo personalInfo)
    {
        var result = await _httpClient.PostAsJsonAsync<PersonalInfo>(_path, personalInfo);
        return result.StatusCode == HttpStatusCode.Created ? true : false;
    }

    /// <summary>
    /// Editar um objecto na base de dados.
    /// </summary>
    /// <param name="personalInfo">Objecto a ser editado</param>
    /// <returns>Verdareiro se for editado, falso caso não</returns>
    public async Task<bool> PutData(PersonalInfo personalInfo)
    {
        var result = await _httpClient.PutAsJsonAsync<PersonalInfo>($"{_path}/{personalInfo.Id}", personalInfo);
        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }

    /// <summary>
    /// Deletar Objecto na Base de Dados
    /// </summary>
    /// <param name="personalInfo">Objecto a ser deletado</param>
    /// <returns>Verdareiro se for delatado, falso caso não</returns>
    public async Task<bool> DeleteData(PersonalInfo personalInfo)
    {
        var result = await _httpClient.DeleteAsync($"{_path}/{personalInfo.Id}");
        return result.StatusCode == HttpStatusCode.NoContent ? true : false;
    }

    /// <summary>
    /// Retorna um objecto na base de dados pelo ID
    /// </summary>
    /// <param name="id">ID do Objecto</param>
    /// <returns>Retorna o objecto</returns>
    public async Task<PersonalInfo> GetDataById(int id) => await _httpClient.GetFromJsonAsync<PersonalInfo>($"/personals/{id}");

    /// <summary>
    /// Retorna todos intens na tabela
    /// </summary>
    /// <returns>Lista dos elementos na base de dados</returns>
    public async Task<List<PersonalInfo>> GetAllData() => await _httpClient.GetFromJsonAsync<List<PersonalInfo>>("/personals");
}
