using LoggingService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
      private readonly ILoggerFactory _loggerFactory;

      public LogController(ILoggerFactory loggerFactory)
      {
          _loggerFactory = loggerFactory;
      }

      [HttpPost]
      public void Post([FromBody] LogEntry logEntry)
      {
            if (!string.IsNullOrEmpty(logEntry.Category))
            {
                var logger = _loggerFactory.CreateLogger(logEntry.Category);
                logger.Log((LogLevel)logEntry.LogLevel, logEntry.Message);
            }        
      }
    }
}
