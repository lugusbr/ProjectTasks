using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Api.Model.Base;

namespace TaskManager.Api.Model
{
    [Table("Task")]
    public class Task: BaseEntity
    {
        
        //[Column("TaskId")]
        //public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public int TaskTypeId { get; set; }


        [ForeignKey("TaskTypeId")]
        public virtual TaskType TaskType { get; set; }

        public virtual ICollection<TaskTime> TaskTimes { get; set; }
    }
}
