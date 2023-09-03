using Application.Common.interfaces;
using Application.Requests;
using Application.Responses;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class StudentService : IStudentService
{
    private IStudentServiceProxy _studentServiceProxy;

    private readonly ILogger<StudentService> _logger;

    public StudentService(IStudentServiceProxy studentServiceProxy, ILogger<StudentService> logger)
    {
        _studentServiceProxy = studentServiceProxy;
        _logger = logger;
    }

    public Task<StudentResponseModel> Get(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id))
            throw new Exception();

        return _studentServiceProxy.GetById(id);
    }

    public async Task<IEnumerable<StudentResponseModel>> GetAll(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        return await _studentServiceProxy.GetAll(pageSize, pageNumber);
    }

    public async Task<IEnumerable<StudentResponseModel>> Search(string searchSymbol,
        CancellationToken cancellationToken)
    {
        return await _studentServiceProxy.Search(searchSymbol, cancellationToken);
    }

    public async Task<string> Create(StudentRequestModel request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
                throw new Exception();
            return await _studentServiceProxy.Create(request);
        }
        catch (Exception)
        {
            throw;
        }
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