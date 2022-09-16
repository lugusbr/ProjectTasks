using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Api.Data.VO;

namespace TaskManager.Api.Business
{
    public interface ITaskBusiness
    {
        TaskVO Create(TaskVO task);
        TaskVO FindByID(int id);
        List<TaskVO> FindByName(string name);
        List<TaskVO> FindAll();
        TaskVO Update(TaskVO task);
        void Delete(int id);
    }

}
