using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Api.Business;
using TaskManager.Api.Data.VO;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskTimeController : ControllerBase
    {
        private readonly ILogger<TaskTimeController> _logger;

        private ITaskTimeBusiness _taskTimeBusiness;

        public TaskTimeController(ILogger<TaskTimeController> logger, ITaskTimeBusiness taskTimeBusiness)
        {
            _logger = logger;
            _taskTimeBusiness = taskTimeBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<TaskTimeVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_taskTimeBusiness.FindAll());
        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(TaskTimeVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var task = _taskTimeBusiness.FindByID(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(TaskTimeVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] TaskTimeVO taskTime)
        {
            if (taskTime == null)
                return BadRequest();
            return Ok(_taskTimeBusiness.Create(taskTime));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _taskTimeBusiness.Delete(id);
            return NoContent();
        }
    }
}
