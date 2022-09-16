using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Data.Converter.Contract;
using TaskManager.Api.Data.VO;
using TaskManager.Api.Model;

namespace TaskManager.Api.Data.Converter.Implementations
{
    public class TaskConverter : IParser<TaskVO, Task>, IParser<Task, TaskVO>
    {
        public Task Parse(TaskVO origin)
        {
            if (origin == null)
                return null;
            var converter = new TaskTypeConverter();
            var taskTimeConverter = new TaskTimeConverter();
            return new Task
            {
                Id = origin.Id,
                Name = origin.Name,
                TaskTypeId = origin.TaskTypeId,
                TaskType = converter.Parse(origin.TaskType),
                TaskTimes = taskTimeConverter.Parse(origin.TaskTimes)
            };
        }

        public List<Task> Parse(List<TaskVO> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public TaskVO Parse(Task origin)
        {
            if (origin == null)
                return null;
            var converter = new TaskTypeConverter();
            var taskTimeConverter = new TaskTimeConverter();
            return new TaskVO
            {
                Id = origin.Id,
                Name = origin.Name,
                TaskTypeId = origin.TaskTypeId,
                TaskType = converter.Parse(origin.TaskType),
                TaskTimes = origin.TaskTimes != null ? taskTimeConverter.Parse(origin.TaskTimes.ToList()) : null
            };
        }

        public List<TaskVO> Parse(List<Task> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
