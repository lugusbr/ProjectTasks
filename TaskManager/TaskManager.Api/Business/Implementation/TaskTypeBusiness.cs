using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Data.Converter.Implementations;
using TaskManager.Api.Data.VO;
using TaskManager.Api.Repository;

namespace TaskManager.Api.Business.Implementation
{
    public class TaskTypeBusiness: ITaskTypeBusiness
    {

        private readonly ITaskTypeRepository _repository;

        private readonly TaskTypeConverter _converter;

        public TaskTypeBusiness(ITaskTypeRepository repository)
        {
            _repository = repository;
            _converter = new TaskTypeConverter();
        }

        public List<TaskTypeVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll().ToList());
        }

        public TaskTypeVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public List<TaskTypeVO> FindByName(string name)
        {
            return _converter.Parse(_repository.FindByName(name));
        }

        public TaskTypeVO Create(TaskTypeVO taskType)
        {
            var TaskTypeEntity = _converter.Parse(taskType);
            TaskTypeEntity = _repository.Create(TaskTypeEntity);
            return _converter.Parse(TaskTypeEntity);
        }

        public TaskTypeVO Update(TaskTypeVO taskType)
        {
            var taskTypeEntity = _converter.Parse(taskType);
            taskTypeEntity = _repository.Update(taskTypeEntity);
            return _converter.Parse(taskTypeEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
