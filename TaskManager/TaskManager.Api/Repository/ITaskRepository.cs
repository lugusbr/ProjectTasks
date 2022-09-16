using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Model;
using TaskManager.Api.Repository.Generic;

namespace TaskManager.Api.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        List<Task> FindByName(string name);
    }
}
