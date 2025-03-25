using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;
using Aspiro.Contracts.ServiceLibrary.DTO;

namespace Aspiro.Impl.ServiceLibrary.Implementations
{
    public class TasksApplicationService : ITasksApplicationService
    {

        private readonly ITasksRepository _tasksRepository;

        public TasksApplicationService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public Task<IActionResult> Create(DTO.TasksCreate tasks)
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

        public Task<IActionResult> Update(DTO.Tasks tasks)
        {
            var result = _tasksRepository.Update(tasks);
            return result;
        }
    }
}
