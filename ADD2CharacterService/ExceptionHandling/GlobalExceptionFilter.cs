using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.Sqlite;

namespace ADD2CharacterService.ExceptionHandling
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status;
            string message;
 
            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(StatRollRuleInvalidException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(SqliteException) &&
                     context.Exception.Message.Contains("UNIQUE constraint failed"))
            {
                message = "Cannot insert duplicate characters played by the same person";
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
 
            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/text";
            response.WriteAsync(message);
        }
    }
}