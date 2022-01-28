using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.Filters
{
    public class LoggerFilterAttribute : IActionFilter
    {
        private readonly ILogger _logger;
        public LoggerFilterAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggerFilterAttribute>();
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Any(kv => kv.Value == null))
            {
                context.Result = new BadRequestObjectResult("Request object cannot be null.");
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogDebug("[path]" + context.HttpContext.Request.Path);
            _logger.LogDebug("[method]" + context.HttpContext.Request.Method);
            _logger.LogDebug("[body]"); //log request body, expectation: { "id" : "1234", "title" : "test", "status" : "draft"}
            _logger.LogDebug("[statuscode]" + context.HttpContext.Response.StatusCode);
            _logger.LogDebug("[response]"); //log response
        }
    }
}
