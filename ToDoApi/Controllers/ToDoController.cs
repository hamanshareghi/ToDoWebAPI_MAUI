using Microsoft.AspNetCore.Mvc;
using ToDoApi.DataService;
using ToDoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ITodoService _todoService;

        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _todoService.GetAll();
            return Ok(data);
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _todoService.GetById(id);
            return Ok(data);
        }

        // POST api/<ToDoController>
        [HttpPost]
        public IActionResult Post([FromBody] ToDo todo)
        {
            _todoService.Add(todo);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDo toDo)
        {
            _todoService.Update(id,toDo);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _todoService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
