using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TaskManager.Api.Business;
using TaskManager.Api.Data.VO;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskTypeController : ControllerBase
    {
        private readonly ILogger<TaskTypeController> _logger;

        private ITaskTypeBusiness _taskTypeBusiness;

        public TaskTypeController(ILogger<TaskTypeController> logger, ITaskTypeBusiness taskTypeBusiness)
        {
            _logger = logger;
            _taskTypeBusiness = taskTypeBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<TaskTypeVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_taskTypeBusiness.FindAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(TaskTypeVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var taskType = _taskTypeBusiness.FindByID(id);
            if (taskType == null) 
                return NotFound();
            return Ok(taskType);
        }

        [HttpGet("findByName")]
        [ProducesResponseType((200), Type = typeof(TaskTypeVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get([FromQuery] string name)
        {
            var taskType = _taskTypeBusiness.FindByName(name);
            if (taskType == null) return NotFound();
            return Ok(taskType);
        }


        [HttpPost]
        [ProducesResponseType((200), Type = typeof(TaskTypeVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] TaskTypeVO taskType)
        {
            if (taskType == null)
                return BadRequest();
            return Ok(_taskTypeBusiness.Create(taskType));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(TaskTypeVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] TaskTypeVO taskType)
        {
            if (taskType == null) return BadRequest();
            return Ok(_taskTypeBusiness.Update(taskType));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _taskTypeBusiness.Delete(id);
            return NoContent();
        }
    }


}
