using Application.Common.interfaces;
using Application.Requests;
using Application.Services;

namespace ApiGateway.Endpoints.Students;

public static class CreateStudentEndpoint
{
    public const string Name = "CreateStudent";

    public static IEndpointRouteBuilder MapCreateStudent(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Student.Create, async (
                StudentRequestModel studentRequestModel, IStudentService studentService,ILogger<StudentService> logger) =>
            {
                try
                {
                    var result= await studentService.Create(studentRequestModel, CancellationToken.None);
                    return result;
                }
                catch (Exception e)
                {
                    logger.LogError(e,e.Message);
                    return e.Message;
                }
            }
        );
        return app;
    }
}