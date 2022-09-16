using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskManager.Api.Data.VO;

namespace TaskManager.Api.Business
{
    public interface ITaskTypeBusiness
    {
        TaskTypeVO Create(TaskTypeVO tasktype);
        TaskTypeVO FindByID(int id);
        List<TaskTypeVO> FindByName(string name);
        List<TaskTypeVO> FindAll();
//        PagedSearchVO<TaskTypeVO> FindWithPagedSearch(
  //          string name, string sortDirection, int pageSize, int page);
        TaskTypeVO Update(TaskTypeVO tasktype);
        void Delete(int id);
    }
}
