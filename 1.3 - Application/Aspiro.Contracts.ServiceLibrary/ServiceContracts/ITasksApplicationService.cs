using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface ITasksApplicationService
    {
        Task<IActionResult> Create(DTO.TasksCreate tasks);
        Task<IActionResult> Read();
        Task<IActionResult> Update(DTO.Tasks taskToUpdate);
        Task<IActionResult> Delete(int id);
    }
}
