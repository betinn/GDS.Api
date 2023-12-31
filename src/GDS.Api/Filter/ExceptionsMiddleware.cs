
using GDS.Api.Model;
using GDS.Api.Model.Response;
using GDS.Api.Util;

namespace GDS.Api.Filter
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = new ErrorResponse();
                switch (ex)
                {
                    
                    case AuthorizationException:
                        var AuthEx = ex as AuthorizationException;
                        errorResponse.Message = AuthEx.exMessage;
                        errorResponse.StatusCode = AuthEx.statuscode;
                        break;
                    default:
                        errorResponse.StatusCode = StatusCodes.Status500InternalServerError;
                        errorResponse.Message = ex.Message;
                        break;
                }

                

                errorResponse.ExceptionType = ex.GetType().Name;
                errorResponse.Exception = ex;

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = errorResponse.StatusCode;
                await context.Response.WriteAsync(errorResponse.ToJson());
            }
        }
        
    }
}
