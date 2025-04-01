using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Library.InfrastructureContracts
{
    public interface ITasksRepository
    {
        Task<IActionResult> Create(DTO.TasksInput tasks);
        Task<IActionResult> Read();
        Task<IActionResult> Update(DTO.TasksInput tasks, int id);
        Task<IActionResult> Delete(int id);
    }
}
