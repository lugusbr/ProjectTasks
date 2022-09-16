using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Api.Model.Base;

namespace TaskManager.Api.Model
{
    [Table("TaskType")]
    public class TaskType: BaseEntity
    {
        //[Key]
        //[Column("TaskTypeId")]
        //public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }

    }
}
