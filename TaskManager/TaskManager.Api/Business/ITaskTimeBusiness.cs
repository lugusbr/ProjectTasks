using System.Collections.Generic;
using TaskManager.Api.Data.VO;

namespace TaskManager.Api.Business
{
    public interface ITaskTimeBusiness
    {
        TaskTimeVO Create(TaskTimeVO tasktime);
        TaskTimeVO FindByID(int id);
        List<TaskTimeVO> FindAll();
        void Delete(int id);

    }
}
