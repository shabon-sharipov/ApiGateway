namespace ApiGateway.Endpoints.Students;

public static class StudentEndpointExtensions
{
    public static IEndpointRouteBuilder MapStudentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCreateStudent();
        app.MapUpdataStudent();
        app.MapDeleteStudent();
        app.MapGetStudent();
        app.MapGetAllStudent();
        app.MapSearchStudent();
        return app;
    }
}