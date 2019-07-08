using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Context;
using CoreApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoController> _logger;

        public TodoController(TodoContext context, ILogger<TodoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.Todos.
              Where(t => t.UserId == Guid.Parse(User.Identity.Name)).
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

            if (todo.UserId != Guid.Parse(User.Identity.Name))
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

            if (todo.UserId != Guid.Parse(User.Identity.Name))
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

            if (todo.UserId != Guid.Parse(User.Identity.Name))
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
            todo.UserId = Guid.Parse(User.Identity.Name);
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = todo.Id }, todo);
        }
    }
}