using Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Library.InfrastructureContracts
{
    public interface IUsersRepository
    {
        Task<IActionResult> Create(Users users);
        Task<IActionResult> Read();
        Task<IActionResult> Update(Users users);
        Task<IActionResult> Delete(int id);
        
        
    }
}
