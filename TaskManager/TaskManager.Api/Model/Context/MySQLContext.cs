using Microsoft.EntityFrameworkCore;

namespace TaskManager.Api.Model.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext()
        {

        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
