using Application.Common.interfaces;
using Application.Requests;
using Application.Services;

namespace ApiGateway.Endpoints.Students;

public static class GetStudentEndpoint
{
    public static IEndpointRouteBuilder MapGetStudent(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Student.Get, async (
            string id, IStudentService studentService) =>
        {
            var result= await studentService.Get(id,CancellationToken.None);
            return result;
        });
        return app;
    }
} 