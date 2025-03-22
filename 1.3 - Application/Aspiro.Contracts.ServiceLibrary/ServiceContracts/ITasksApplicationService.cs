using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface ITasksApplicationService
    {
        Task<IActionResult> Create();
        Task<IActionResult> Read();
        Task<IActionResult> Update();
        Task<IActionResult> Delete();
    }
}
