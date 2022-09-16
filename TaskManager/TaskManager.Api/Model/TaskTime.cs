using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Api.Model.Base;

namespace TaskManager.Api.Model
{
    [Table("TaskTime")]
    public class TaskTime : BaseEntity
    {
        [Column("StartDateTime")]
        public DateTime StartDateTime { get; set; }
        [Column("EndDateTime")]
        public DateTime EndDateTime { get; set; }
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }

    }
}
