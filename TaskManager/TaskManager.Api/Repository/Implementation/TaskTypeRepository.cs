using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Model;
using TaskManager.Api.Model.Context;
using TaskManager.Api.Repository.Generic;

namespace TaskManager.Api.Repository.Implementation
{
    public class TaskTypeRepository: GenericRepository<TaskType>, ITaskTypeRepository
    {
        public TaskTypeRepository(MySQLContext context) : base(context) { }

        public List<TaskType> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.TaskTypes.Where(
                    x => x.Name.Contains(name)).ToList();
            }

            return null;
        }
    }
}
