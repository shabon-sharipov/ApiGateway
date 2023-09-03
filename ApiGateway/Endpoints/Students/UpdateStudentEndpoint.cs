using Application.Common.interfaces;
using Application.Requests;

namespace ApiGateway.Endpoints.Students;

public static class UpdateStudentEndpoint
{
    public static IEndpointRouteBuilder MapUpdataStudent(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.Student.Update,
            async (IStudentService studentService, string id, StudentRequestModel studentRequestModel) =>
            {
                var result = await studentService.Update(studentRequestModel, id, CancellationToken.None);
                return result;
            });
        return app;
    }
}