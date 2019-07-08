namespace LoggingService.Model
{
  public class LogEntry
  {
    public string Category { get; set; }
    public string Message { get; set; }
    public int LogLevel { get; set; }
  }
}