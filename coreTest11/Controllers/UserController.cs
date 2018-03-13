using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coreTest11.Data;
using coreTest11.Models;

namespace coreTest11.Controllers
{
    [Produces("application/json")]
    [Route("User")]
    public class UserController : Controller
    {

        private readonly SchoolDbContext _context;

        public UserController(SchoolDbContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new Users { FirstName = "Item1" });
                _context.SaveChanges();
            }


        }

        [HttpGet]
        public IEnumerable<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUserList")]
        public IActionResult GetById(string id)
        {
            var item = _context.Users.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] TodoItem item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }

        //    _context.TodoItems.Add(item);
        //    _context.SaveChanges();

        //    return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(long id, [FromBody] TodoItem item)
        //{
        //    if (item == null || item.Id != id)
        //    {
        //        return BadRequest();
        //    }

        //    var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    todo.IsComplete = item.IsComplete;
        //    todo.Name = item.Name;

        //    _context.TodoItems.Update(todo);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}


        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoItems.Remove(todo);
        //    _context.SaveChanges();
        //    return new NoContentResult();
        //}




    }
}