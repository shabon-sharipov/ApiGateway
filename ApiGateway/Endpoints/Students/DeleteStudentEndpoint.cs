using Application.Common.interfaces;

namespace ApiGateway.Endpoints.Students;

public static class DeleteStudentEndpoint
{
    public static IEndpointRouteBuilder MapDeleteStudent(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.Student.Delete, async (
            string id, IStudentService studentService) =>
        {
            var result= await studentService.Delete(id, CancellationToken.None);
            return result;
        });
        return app;
    }
}