using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Model;
using TaskManager.Api.Model.Context;
using TaskManager.Api.Repository.Generic;

namespace TaskManager.Api.Repository.Implementation
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(MySQLContext context) : base(context) { }

        public List<Task> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.Tasks.Where(
                    x => x.Name.Contains(name)).ToList();
            }

            return null;
        }

    }
}
