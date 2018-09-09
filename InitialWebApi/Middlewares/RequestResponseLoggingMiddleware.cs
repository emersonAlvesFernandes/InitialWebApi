using InitialWebApi.Model;
using InitialWebApi.Model.Contracts;
using InitialWebApi.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialWebApi.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private ILogRepository _logRepository;

        /// <summary>
        /// implementação baseada no artigo de Matthew jones
        /// https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
        /// </summary>
        /// <param name="next"></param>
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                _logRepository = (ILogRepository)context.RequestServices.GetService(typeof(ILogRepository));
            }
            catch(Exception ex)
            {
                throw ex;
            }


            //var request = await FormatRequestAsync(context.Request);

            //var originalBodyStream = context.Response.Body;

            await _next(context);

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                //await _next(context);

                var response = await FormatResponse(context.Response);

                var request = await FormatRequestAsync(context.Request);

                var originalBodyStream = context.Response.Body;

                _logRepository.Save(new PipelineLogData(request, response));

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<RequestLog> FormatRequestAsync(HttpRequest request)
        {
            var body = request.Body;

            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            return new RequestLog(request.Scheme, request.Host.ToString(), request.Path, request.QueryString.ToString(), bodyAsText);

        }

        private async Task<ResponseLog> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var text = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return new ResponseLog(response.StatusCode, text);
        }
    }
}
