using Application.Common.interfaces;
using Application.Requests;
using Application.Responses;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Application.Common;
using Newtonsoft.Json;

namespace Application.Gateways;

public class StudentServiceProxy:IStudentServiceProxy
{
    private HttpClient _client;
    public StudentServiceProxy()
    {
        _client = new HttpClient();
    }
    public async Task<string> Create(StudentRequestModel studentRequestModel)
    {
        var json = JsonConvert.SerializeObject(studentRequestModel);
        
        _client.BaseAddress = new Uri(ApiConstant.BaseUrlSrudentService);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("Student", content);

        if (!response.IsSuccessStatusCode)
            throw new Exception();
        var responseJson = await response.Content.ReadAsStringAsync();
        return responseJson;
    }

    public async Task<StudentResponseModel> GetById(string id)
    {
        _client.BaseAddress = new Uri(ApiConstant.BaseUrlSrudentService);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var content = new StringContent(id, Encoding.UTF8, "application/json");
        var response = await _client.GetAsync($"Student?id={id}");

        if (!response.IsSuccessStatusCode)
        if (!response.IsSuccessStatusCode)
            throw new Exception();
        
        var responseJson = await response.Content.ReadAsStringAsync();

        var respons = JsonConvert.DeserializeObject<StudentResponseModel>(responseJson);
        return respons;
    }

    public async Task<string> Updata(string id, StudentRequestModel studentRequestModel, CancellationToken cancellationToken)
    {
        var json = JsonConvert.SerializeObject(studentRequestModel);
        _client.BaseAddress = new Uri(ApiConstant.BaseUrlSrudentService);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"Student?id={id}",content);

        if (!response.IsSuccessStatusCode)
            if (!response.IsSuccessStatusCode)
                throw new Exception();
        
        var responseJson = await response.Content.ReadAsStringAsync();
        return responseJson;
    }
    
    public async Task<string> DeleteAsync(string id,CancellationToken cancellationToken)
    {
        _client.BaseAddress = new Uri(ApiConstant.BaseUrlSrudentService);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var content = new StringContent(id, Encoding.UTF8, "application/json");
        var response = await _client.DeleteAsync($"Student?id={id}");

        if (!response.IsSuccessStatusCode)
            if (!response.IsSuccessStatusCode)
                throw new Exception();
        
        var responseJson = await response.Content.ReadAsStringAsync();

       return responseJson;
    }
    
}