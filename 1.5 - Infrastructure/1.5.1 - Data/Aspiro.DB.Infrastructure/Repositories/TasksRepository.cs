using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.DB.Infrastructure.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        public Task<IActionResult> Create(DTO.Tasks tasks)
        {
            throw new NotImplementedException();
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
