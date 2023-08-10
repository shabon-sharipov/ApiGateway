using Application.Requests;
using Application.Responses;

namespace Application.Common.interfaces;

public interface IStudentServiceProxy
{
    Task<string> Create(StudentRequestModel studentRequestModel);
    Task<StudentResponseModel> GetById(string id);
    Task<string> Updata(string id, StudentRequestModel studentRequestModel,CancellationToken cancellationToken);
    Task<string> DeleteAsync(string id, CancellationToken cancellationToken);
    Task<List<StudentResponseModel>> GetAll(int pageSize = 10, int pageNumber = 1);
    Task<List<StudentResponseModel>> Search(string searchSymbol, CancellationToken cancellationToken);
}