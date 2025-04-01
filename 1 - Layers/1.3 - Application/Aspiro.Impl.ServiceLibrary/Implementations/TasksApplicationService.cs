using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Impl.ServiceLibrary.Implementations
{
    public class TasksApplicationService : ITasksApplicationService
    {

        private readonly ITasksRepository _tasksRepository;

        public TasksApplicationService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public Task<IActionResult> Create(DTO.TasksInput tasks)
        {
            var result = _tasksRepository.Create(tasks);
            return result;
        }

        public Task<IActionResult> Delete(int id)
        {
            var result = _tasksRepository.Delete(id);
            return result;
        }

        public Task<IActionResult> Read()
        {
            var result = _tasksRepository.Read();
            return result;
        }

        public Task<IActionResult> Update(DTO.TasksInput tasks, int id)
        {
            var result = _tasksRepository.Update(tasks, id);
            return result;
        }
    }
}
