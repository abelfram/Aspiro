using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Library.InfrastructureContracts
{
    public interface ITasksRepository
    {
        Task<IActionResult> Create(DTO.TasksCreate tasks);
        Task<IActionResult> Read();
        Task<IActionResult> Update(DTO.Tasks tasks);
        Task<IActionResult> Delete(int id);
    }
}
