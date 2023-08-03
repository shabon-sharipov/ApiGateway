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
        throw new NotImplementedException();
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
        return await _studentServiceProxy.SendToStudentServiceForAddToMongoDb(request);
    }

    public Task<string> Update(StudentRequestModel request, string id,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public bool Delete(ulong id, CancellationToken cancellationTok)
    {
        throw new NotImplementedException();
    }
}