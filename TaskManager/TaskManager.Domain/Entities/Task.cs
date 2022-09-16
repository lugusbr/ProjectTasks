using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{
    [Table("Task")]
    public class Task
    {
        [Column("TaskId")]
        public int TaskId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("StartDateTime")]
        public DateTime StartDateTime { get; set; }
        [Column("EndDateTime")]
        public DateTime? EndDateTime { get; set; }

        public int SubTaskId { get; set; }
        [ForeignKey("SubTaskId")]
        public SubTask SubTask { get; set; }
    }
}
