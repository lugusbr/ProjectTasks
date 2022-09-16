using System.Collections.Generic;
using TaskManager.Api.Model;
using TaskManager.Api.Repository.Generic;

namespace TaskManager.Api.Repository
{
    public interface ITaskTypeRepository : IRepository<TaskType>
    {
        List<TaskType> FindByName(string name);
    }
}
