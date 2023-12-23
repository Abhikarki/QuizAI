using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using todo.Models;
using toDoTasks.Services;

namespace todo.Controllers
{
    [ApiController]
    [Route("/task")]
    public class TaskController : Controller
    {
        public readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService; 
        }

        [HttpGet]
        [Route("taskData")]
        public async Task<IActionResult> Get()
        {
            var sqlQuery = "SELECT * FROM c";
            var result = await _taskService.Get(sqlQuery);
            return Ok(result);
        }
    }
}
