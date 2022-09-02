using DiApi.Utility;

namespace DiApi.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOperationTransient _transient;
        private readonly IOperationSingleton _singleton;

        public CustomMiddleware(RequestDelegate next,
                                IOperationTransient transient,
                                IOperationSingleton singleton)
        {
            _next = next;
            _transient = transient;
            _singleton = singleton;
        }

        public async Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext context, IOperationScoped scoped)
        {
            Console.WriteLine($"Middleware; TransientId: {_transient.OperationId} ScopedId: {scoped.OperationId} Singleton: {_singleton.OperationId}");
            await _next(context);
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}