using Application.Common.interfaces;
using Application.Requests;
using Application.Responses;

namespace Application.Services;

public class StudentService : IStudentService
{
    private IStudentServiceProxy _studentServiceProxy;

    public StudentService(IStudentServiceProxy studentServiceProxy)
    {
        _studentServiceProxy = studentServiceProxy;
    }

    public Task<StudentResponseModel> Get(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id))
            throw new Exception();

        return _studentServiceProxy.GetById(id);
    }

    public Task<IEnumerable<StudentResponseModel>> GetAll(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Create(StudentRequestModel request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();
        return await _studentServiceProxy.Create(request);
    }

    public Task<string> Update(StudentRequestModel request, string id,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id) || request is null)
            throw new Exception();

        return _studentServiceProxy.Updata(id, request, cancellationToken);
    }

    public async Task<string> Delete(string id, CancellationToken cancellationTok)
    {
        return await _studentServiceProxy.DeleteAsync(id, cancellationTok);
    }
}