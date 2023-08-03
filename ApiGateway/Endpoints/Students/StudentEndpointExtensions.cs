namespace ApiGateway.Endpoints.Students;

public static class StudentEndpointExtensions
{
    public static IEndpointRouteBuilder MapMovieEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCreateStudent();
        return app;
    }
}