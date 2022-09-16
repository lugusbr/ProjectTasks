using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Data.Converter.Implementations;
using TaskManager.Api.Data.VO;
using TaskManager.Api.Repository;

namespace TaskManager.Api.Business.Implementation
{
    public class TaskTimeBusiness : ITaskTimeBusiness
    {
        private readonly ITaskTimeRepository _repository;

        private readonly TaskTimeConverter _converter;

        public TaskTimeBusiness(ITaskTimeRepository repository)
        {
            _repository = repository;
            _converter = new TaskTimeConverter();
        }
        public TaskTimeVO Create(TaskTimeVO tasktime)
        {
            var taskTimeEntity = _converter.Parse(tasktime);
            taskTimeEntity = _repository.Create(taskTimeEntity);
            return _converter.Parse(taskTimeEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<TaskTimeVO> FindAll()
        {

            return _converter.Parse(
                _repository
                .FindAll()
                .ToList()
                );
        }

        public TaskTimeVO FindByID(int id)
        {
            return _converter.Parse(
                _repository
                .FindByID(id)
                );
        }

    }
}
