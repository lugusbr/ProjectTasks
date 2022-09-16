using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Data.Converter.Contract;
using TaskManager.Api.Data.VO;
using TaskManager.Api.Model;

namespace TaskManager.Api.Data.Converter.Implementations
{
    public class TaskTimeConverter : IParser<TaskTimeVO, TaskTime>, IParser<TaskTime, TaskTimeVO>
    {
        public TaskTime Parse(TaskTimeVO origin)
        {
            if (origin == null)
                return null;
            return new TaskTime
            {
                Id = origin.Id,
                StartDateTime = origin.StartDateTime,
                EndDateTime = origin.EndDateTime,
                TaskId = origin.TaskId
            };
        }

        public List<TaskTime> Parse(List<TaskTimeVO> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public TaskTimeVO Parse(TaskTime origin)
        {
            if (origin == null)
                return null;
            return new TaskTimeVO
            {
                Id = origin.Id,
                StartDateTime = origin.StartDateTime,
                EndDateTime = origin.EndDateTime,
                TaskId = origin.TaskId
            };
        }

        public List<TaskTimeVO> Parse(List<TaskTime> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
