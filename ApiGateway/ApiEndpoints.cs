namespace ApiGateway;

public class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class Student
    {
        private const string Base = $"{ApiBase}/Student";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id}}";
        public const string Search = $"{Base}/search";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id}}";
        public const string Delete = $"{Base}/{{id}}";
    }
}