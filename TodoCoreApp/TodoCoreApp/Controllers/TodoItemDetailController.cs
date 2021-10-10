using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoCoreApp.Models;

namespace TodoCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemDetailController : ControllerBase
    {
        private readonly TodoItemDetailContext _context;

        public TodoItemDetailController(TodoItemDetailContext context)
        {
            _context = context;
        }

        // GET: api/TodoItemDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDetail>>> GetTodoItemDetails()
        {
            return await _context.TodoItemDetails.ToListAsync();
        }

        // GET: api/TodoItemDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDetail>> GetTodoItemDetail(int id)
        {
            var todoItemDetail = await _context.TodoItemDetails.FindAsync(id);

            if (todoItemDetail == null)
            {
                return NotFound();
            }

            return todoItemDetail;
        }

        // PUT: api/TodoItemDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemDetail(int id, TodoItemDetail todoItemDetail)
        {
            if (id != todoItemDetail.TodoItemId)
            {
                return BadRequest();
            }

            _context.Entry(todoItemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItemDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDetail>> PostTodoItemDetail(TodoItemDetail todoItemDetail)
        {
            _context.TodoItemDetails.Add(todoItemDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItemDetail", new { id = todoItemDetail.TodoItemId }, todoItemDetail);
        }

        // DELETE: api/TodoItemDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItemDetail(int id)
        {
            var todoItemDetail = await _context.TodoItemDetails.FindAsync(id);
            if (todoItemDetail == null)
            {
                return NotFound();
            }

            _context.TodoItemDetails.Remove(todoItemDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemDetailExists(int id)
        {
            return _context.TodoItemDetails.Any(e => e.TodoItemId == id);
        }
    }
}
