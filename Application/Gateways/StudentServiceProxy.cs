using Application.Common.interfaces;
using Application.Requests;
using Application.Responses;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Application.Gateways;

public class StudentServiceProxy:IStudentServiceProxy
{
    public async Task<string> SendToStudentServiceForAddToMongoDb(StudentRequestModel studentRequestModel)
    {
        var json = JsonConvert.SerializeObject(studentRequestModel);
        using var client = new HttpClient();

        client.BaseAddress = new Uri("http://localhost:5010/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("Student", content);

        if (!response.IsSuccessStatusCode)
            throw new Exception();
        var responseJson = await response.Content.ReadAsStringAsync();
        return responseJson;
    }
}