using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Api.Data.VO
{
    public class TaskVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
        public TaskTypeVO TaskType { get; set; }
        public List<TaskTimeVO> TaskTimes { get; set; }
    }
}
