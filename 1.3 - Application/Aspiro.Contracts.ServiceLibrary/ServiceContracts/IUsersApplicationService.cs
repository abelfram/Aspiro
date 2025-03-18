using Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface IAspiroApplicationService
    {
        Task<IActionResult> Create(Users users);
        Task<IActionResult> Read();
        Task<IActionResult> Update(Users users);
        Task<IActionResult> Delete(int id);
        
    }
}
