using Application.Common.interfaces;
using Application.Requests;
using Application.Responses;
using System.Net.Http.Headers;
using System.Text;
using Application.Common;
using Newtonsoft.Json;
using System.Net.Http;

namespace Application.Gateways;

public class StudentServiceProxy : IStudentServiceProxy
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StudentServiceProxy(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> Create(StudentRequestModel studentRequestModel)
    {
        try
        {
            var json = JsonConvert.SerializeObject(studentRequestModel);
            var client = _httpClientFactory.CreateClient(ApiConstant.StudentServiceHttpClient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Student", content);

            if (!response.IsSuccessStatusCode)
                throw new Exception();
            var responseJson = await response.Content.ReadAsStringAsync();
            return responseJson;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<StudentResponseModel> GetById(string id)
    {
        var _client = _httpClientFactory.CreateClient(ApiConstant.StudentServiceHttpClient);
        var content = new StringContent(id, Encoding.UTF8, "application/json");
        var result = await _client.GetAsync($"Student?id={id}");

        if (!result.IsSuccessStatusCode)
            if (!result.IsSuccessStatusCode)
                throw new Exception();

        var responseJson = await result.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<StudentResponseModel>(responseJson);
        return response;
    }

    public async Task<string> Updata(string id, StudentRequestModel studentRequestModel,
        CancellationToken cancellationToken)
    {
        var _client = _httpClientFactory.CreateClient(ApiConstant.StudentServiceHttpClient);
        var json = JsonConvert.SerializeObject(studentRequestModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"Student?id={id}", content);

        if (!response.IsSuccessStatusCode)
            if (!response.IsSuccessStatusCode)
                throw new Exception();

        var responseJson = await response.Content.ReadAsStringAsync();
        return responseJson;
    }

    public async Task<string> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var _client = _httpClientFactory.CreateClient(ApiConstant.StudentServiceHttpClient);
        var content = new StringContent(id, Encoding.UTF8, "application/json");
        var response = await _client.DeleteAsync($"Student?id={id}");

        if (!response.IsSuccessStatusCode)
            if (!response.IsSuccessStatusCode)
                throw new Exception();

        var responseJson = await response.Content.ReadAsStringAsync();

        return responseJson;
    }

    public async Task<List<StudentResponseModel>> GetAll(int pageSize = 10, int pageNumber = 1)
    {
        var _client = _httpClientFactory.CreateClient(ApiConstant.SearchSyncServiceHttpClient);
        var response = await _client.GetAsync($"Student?pageSize={pageSize}&pageNumber={pageNumber}");

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var responseJson = await response.Content.ReadAsStringAsync();
        var respons = JsonConvert.DeserializeObject<List<StudentResponseModel>>(responseJson);

        return respons;
    }

    public async Task<List<StudentResponseModel>> Search(string searchSymbol, CancellationToken cancellationToken)
    {
        var _client = _httpClientFactory.CreateClient(ApiConstant.SearchSyncServiceHttpClient);
        var response = await _client.GetAsync($"Student/Search?searchSymbol={searchSymbol}");

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var responseJson = await response.Content.ReadAsStringAsync();
        var respons = JsonConvert.DeserializeObject<List<StudentResponseModel>>(responseJson);

        return respons;
    }
}