using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TaskManager.Api.Business;
using TaskManager.Api.Data.VO;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;

        private ITaskBusiness _taskBusiness;

        public TaskController(ILogger<TaskController> logger, ITaskBusiness taskBusiness)
        {
            _logger = logger;
            _taskBusiness = taskBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<TaskVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_taskBusiness.FindAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(TaskVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var task = _taskBusiness.FindByID(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("findByName")]
        [ProducesResponseType((200), Type = typeof(TaskVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get([FromQuery] string name)
        {
            var taskType = _taskBusiness.FindByName(name);
            if (taskType == null) return NotFound();
            return Ok(taskType);
        }


        [HttpPost]
        [ProducesResponseType((200), Type = typeof(TaskVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] TaskVO task)
        {
            if (task == null) 
                return BadRequest();
            return Ok(_taskBusiness.Create(task));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(TaskVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] TaskVO task)
        {
            if (task == null) 
                return BadRequest();
            return Ok(_taskBusiness.Update(task));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _taskBusiness.Delete(id);
            return NoContent();
        }
    }
}
