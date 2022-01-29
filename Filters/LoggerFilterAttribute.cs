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
            _logger.LogInformation("[Request Body]" + context.HttpContext.Request.Body); //log response
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("[Response Body]" + context.HttpContext.Response.Body); //log response
        }
    }
}
