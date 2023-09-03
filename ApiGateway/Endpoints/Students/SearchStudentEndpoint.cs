using Application.Common.interfaces;

namespace ApiGateway.Endpoints.Students;

public static class SearchStudentEndpoint
{
    public static IEndpointRouteBuilder MapSearchStudent(this IEndpointRouteBuilder app)
    {
        
        app.MapGet(ApiEndpoints.Student.Search, async (
            string searchSymbol, IStudentService studentService) =>
        {
            var result= await studentService.Search(searchSymbol, CancellationToken.None);
            return result;
        });
        return app;
    }
}