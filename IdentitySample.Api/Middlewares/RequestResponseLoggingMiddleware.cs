using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentitySample.Api.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
                                            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory
                      .CreateLogger<RequestResponseLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(await FormatRequest(context.Request));

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                _logger.LogInformation(await FormatResponse(context.Response));
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            try
            {
                var body = request.Body;
                request.EnableRewind();

                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body = body;

                var result = $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";

                return result;
            }
            catch (Exception ex)
            {

                return "";
            }

        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            try
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                var text = await new StreamReader(response.Body).ReadToEndAsync();
                response.Body.Seek(0, SeekOrigin.Begin);
                var result = $"Response {text}";

                return result;
            }
            catch (Exception ex)
            {

                return "";
            }

        }

    }
}
