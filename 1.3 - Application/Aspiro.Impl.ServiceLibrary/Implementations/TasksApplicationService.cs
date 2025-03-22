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
            tasksRepository = _tasksRepository;
        }

        public Task<IActionResult> Create(DTO.Tasks tasks)
        {
            var result = _tasksRepository.Create(tasks);
            return result;
        }

        public Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Read()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }
    }
}
