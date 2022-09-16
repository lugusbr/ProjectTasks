using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Api.Data.Converter.Implementations;
using TaskManager.Api.Data.VO;
using TaskManager.Api.Repository;

namespace TaskManager.Api.Business.Implementation
{
    public class TaskBusiness : ITaskBusiness
    {

        private readonly ITaskRepository _repository;

        private readonly TaskConverter _converter;

        private readonly ITaskTimeBusiness _taskTimeBusiness;

        public TaskBusiness(ITaskRepository repository, ITaskTimeBusiness taskTimeBusiness)
        {
            _repository = repository;
            _converter = new TaskConverter();
            _taskTimeBusiness = taskTimeBusiness;
        }
        public TaskVO Create(TaskVO task)
        {
            var taskEntity = _converter.Parse(task);
            taskEntity = _repository.Create(taskEntity);
            return _converter.Parse(taskEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<TaskVO> FindAll()
        {

            return _converter.Parse(
                _repository
                .FindAll()
                .Include(x => x.TaskType)
                .Include(x => x.TaskTimes)
                .ToList());
        }

        public TaskVO FindByID(int id)
        {
            //return _converter.Parse(
            //    _repository.FindByID(id, e => e.TaskType, e => e.TaskTimes)
            //    );
            return _converter.Parse(
                _repository
                .FindAll()
                .Include(x => x.TaskType)
                .Include(x => x.TaskTimes)
                .Where(x => x.Id == id)
                .FirstOrDefault());
        }

        public List<TaskVO> FindByName(string name)
        {
            return _converter.Parse(_repository.FindByName(name));
        }

        public TaskVO Update(TaskVO task)
        {
            //todo: Como fazer isso melhor?
            foreach(var tt in task.TaskTimes.Where(x => x.Id == 0).ToList())
            {
                _taskTimeBusiness.Create(tt);
            }

            var taskEntity = _converter.Parse(task);
            taskEntity = _repository.Update(taskEntity);
            return _converter.Parse(taskEntity);
        }
    }
}
