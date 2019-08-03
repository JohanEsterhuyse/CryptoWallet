using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CryptoWallet.Notification.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IHostingEnvironment hostingEnvironment)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log(httpContext, ex, hostingEnvironment);
                throw;
            }
        }

        //Todo: Extract this as some logger Nuget package
        private void Log(HttpContext context, Exception exception, IHostingEnvironment hostingEnvironment)
        {
            var savePath = hostingEnvironment.WebRootPath;
            var now = DateTime.UtcNow;
            var fileName = $"{now.ToString("yyyy_MM_dd")}.log";
            var filePath = Path.Combine(savePath, "logs", fileName);

            // ensure that directory exists
            new FileInfo(filePath).Directory.Create();

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine($"{now.ToString("HH:mm:ss")} {context.Request.Path}");
                writer.WriteLine(exception.Message);
            }
        }
    }
}
