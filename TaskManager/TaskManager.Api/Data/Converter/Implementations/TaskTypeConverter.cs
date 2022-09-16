using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Api.Data.Converter.Contract;
using TaskManager.Api.Data.VO;
using TaskManager.Api.Model;

namespace TaskManager.Api.Data.Converter.Implementations
{
    public class TaskTypeConverter : IParser<TaskTypeVO, TaskType>, IParser<TaskType, TaskTypeVO>
    {
        public TaskType Parse(TaskTypeVO origin)
        {
            if (origin == null) 
                return null;
            return new TaskType
            {
                Id = origin.id ?? 0,
                Name = origin.name
            };
        }

        public List<TaskType> Parse(List<TaskTypeVO> origin)
        {
            if (origin == null) 
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public TaskTypeVO Parse(TaskType origin)
        {
            if (origin == null)
                return null;
            return new TaskTypeVO
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public List<TaskTypeVO> Parse(List<TaskType> origin)
        {
            if (origin == null)
                return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
