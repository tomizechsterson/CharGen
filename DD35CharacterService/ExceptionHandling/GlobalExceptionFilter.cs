﻿using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DD35CharacterService.ExceptionHandling
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status;
            string message;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(DuplicateAddException))
            {
                message = context.Exception.Message;
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