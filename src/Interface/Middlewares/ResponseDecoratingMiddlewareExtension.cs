using Microsoft.AspNetCore.Builder;

namespace ShareFlow.Interface.Middlewares
{
    /// <summary>
    /// Describe extension method to use ResponseDecoratingMiddleware
    /// </summary>
    public static class ResponseDecoratingMiddlewareExtension
    {
        /// <summary>
        /// Init the ResponseDecoratingMiddleware
        /// </summary>
        /// <param name="app">Instance of</param>
        public static IApplicationBuilder UseResponseDecorating(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ResponseDecoratingMiddleware>();
        }
    }
}