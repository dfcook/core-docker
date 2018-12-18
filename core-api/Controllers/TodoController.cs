using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_api.Context;
using core_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
  [Route("api/[controller]")]
  public class TodoController : Controller
  {
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Todo> Get()
    {
      return _context.Todos;
    }
  }
}
