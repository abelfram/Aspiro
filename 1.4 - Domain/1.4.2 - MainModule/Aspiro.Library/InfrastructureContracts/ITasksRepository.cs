using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Library.InfrastructureContracts
{
    public interface ITasksRepository
    {
        Task<IActionResult> Create();
        Task<IActionResult> Read();
        Task<IActionResult> Update();
        Task<IActionResult> Delete();
    }
}
