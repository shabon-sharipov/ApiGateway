using Application.Common.interfaces;
using Application.Services;

namespace ApiGateway.Endpoints.Students;

public static class GetAllStudentEndpoint
{
    public static IEndpointRouteBuilder MapGetAllStudent(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Student.GetAll, async (
            int pageSize, int pageNumber, IStudentService studentService, ILogger<StudentService> logger) =>
            {
                try
                {
                    var result = await studentService.GetAll(pageSize, pageNumber, CancellationToken.None);
                    return result;
                }
                catch (Exception e)
                {
                    logger.LogError(e,"Hello!!");
                    throw;
                }
            }

        );
        return app;
    }
}