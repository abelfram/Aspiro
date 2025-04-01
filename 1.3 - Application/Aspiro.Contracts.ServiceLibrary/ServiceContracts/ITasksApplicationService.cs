using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface ITasksApplicationService
    {
        Task<IActionResult> Create(DTO.TasksInput tasks);
        Task<IActionResult> Read();
        Task<IActionResult> Update(DTO.TasksInput taskToUpdate, int id);
        Task<IActionResult> Delete(int id);
    }
}
