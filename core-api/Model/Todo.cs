using System;

namespace CoreApi.Model
{
  public class Todo
  {
    public long Id { get; set; }
    public string Text { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; }
  }
}