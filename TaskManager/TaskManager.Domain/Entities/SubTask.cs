using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Domain.Entities
{
    [Table("SubTask")]
    public class SubTask
    {
        [Key]
        [Column("SubTaskId")]
        public int SubTaskId { get; set; }
        [Column("Name")]
        public string  Name { get; set; }
    }
}
