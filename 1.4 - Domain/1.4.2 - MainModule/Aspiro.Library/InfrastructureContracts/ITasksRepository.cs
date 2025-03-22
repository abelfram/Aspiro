using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Library.InfrastructureContracts
{
    public interface ITasksRepository
    {
        Task<IActionResult> Create(DTO.Tasks tasks);
        Task<IActionResult> Read();
        Task<IActionResult> Update();
        Task<IActionResult> Delete();
    }
}
