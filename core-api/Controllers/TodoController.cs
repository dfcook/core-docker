using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Context;
using CoreApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Controllers
{
  [Route("api/[controller]")]
  public class TodoController : Controller
  {
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
        _context = context;
    }

    private Guid GetOrCreateUserId()
    {
      var id = HttpContext.Session.GetString("id");
      Guid userId;

      if (String.IsNullOrEmpty(id) || !Guid.TryParse(id, out userId))
      {
        userId = Guid.NewGuid();
        HttpContext.Session.SetString("id", userId.ToString());
      }

      return userId;
    }

    [HttpGet]
    public async Task<IEnumerable<Todo>> Get()
    {
      var userId = GetOrCreateUserId();
      return await _context.Todos.
        Where(t => t.UserId == userId).
        ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> Get(int id)
    {
      var todo = await _context.Todos.FindAsync(id);

      if (todo == null)
      {
        return NotFound();
      }

      if (todo.UserId != GetOrCreateUserId())
      {
        return Forbid();
      }

      return todo;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var todo = await _context.Todos.SingleOrDefaultAsync(t => t.Id == id);

      if (todo == null)
      {
        return NotFound();
      }

      if (todo.UserId != GetOrCreateUserId())
      {
        return Forbid();
      }

      _context.Todos.Remove(todo);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Todo>> Put(int id, [FromBody] Todo todo)
    {
      if (id != todo.Id)
      {
        return BadRequest();
      }

      if (todo.UserId != GetOrCreateUserId())
      {
        return Forbid();
      }

      _context.Entry(todo).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return todo;
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> Post([FromBody] Todo todo)
    {
      todo.UserId = GetOrCreateUserId();
      _context.Todos.Add(todo);
      await _context.SaveChangesAsync();

      return CreatedAtAction("Get", new { id = todo.Id }, todo);
    }
  }
}
