using Application.Common.interfaces;
using Application.Requests;

namespace ApiGateway.Endpoints.Students;

public static class CreateStudentEndpoint
{
    public const string Name = "CreateStudent";

    public static IEndpointRouteBuilder MapCreateStudent(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Student.Create, async (
                StudentRequestModel studentRequestModel, IStudentService studentService) =>
            {
                var student= await studentService.Create(studentRequestModel, CancellationToken.None);
                return student;
            }

        );
        return app;
    }
}