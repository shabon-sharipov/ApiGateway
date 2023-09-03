using ApiGateway.Endpoints.Students;

namespace ApiGateway.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapStudentEndpoints();
        return app;
    }
}