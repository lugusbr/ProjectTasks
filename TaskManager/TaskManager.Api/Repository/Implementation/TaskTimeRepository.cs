using TaskManager.Api.Model;
using TaskManager.Api.Model.Context;
using TaskManager.Api.Repository.Generic;

namespace TaskManager.Api.Repository.Implementation
{
    public class TaskTimeRepository : GenericRepository<TaskTime>, ITaskTimeRepository
    {
        public TaskTimeRepository(MySQLContext context) : base(context) { }
    }
}
