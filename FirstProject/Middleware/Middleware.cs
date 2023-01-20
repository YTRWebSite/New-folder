using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service;
using System.Threading.Tasks;

namespace FirstProject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
    
        private readonly RequestDelegate _next;
        //private readonly IRatingService _IRatingService;
        public Middleware(RequestDelegate next)
        {
            _next = next;
            //_IRatingService = IRatingService;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
          
            Rating rating = new Rating

            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                RecordDate = new DateTime()

            };
            await ratingService.add_request(rating);
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddleExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
