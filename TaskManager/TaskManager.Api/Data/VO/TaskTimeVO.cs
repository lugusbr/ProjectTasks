using System;

namespace TaskManager.Api.Data.VO
{
    public class TaskTimeVO
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TaskId { get; set; }
    }
}
