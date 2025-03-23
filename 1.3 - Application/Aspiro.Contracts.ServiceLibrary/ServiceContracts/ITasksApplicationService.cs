using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface ITasksApplicationService
    {
        Task<IActionResult> Create(DTO.Tasks tasks);
        Task<IActionResult> Read();
        Task<IActionResult> Update();
        Task<IActionResult> Delete();
    }
}
