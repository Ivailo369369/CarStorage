using System.Net;

using CarStorage.Core.Application.Common.Exceptions;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarStorage.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ModelValidationException modelValidationException:
                    code = HttpStatusCode.BadRequest;
                    result = SerializeObject(new
                    {
                        ValidationDetails = true,
                        modelValidationException.Errors
                    });
                    break;
                case NullReferenceException _:
                    code = HttpStatusCode.BadRequest;
                    result = SerializeObject(new[] { "Invalid request." });
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                var error = exception.Message;

                result = SerializeObject(new[] { error });
            }

            return context.Response.WriteAsync(result);
        }

        private static string SerializeObject(object obj)
            => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(true, true)
                }
            });
    }
}
