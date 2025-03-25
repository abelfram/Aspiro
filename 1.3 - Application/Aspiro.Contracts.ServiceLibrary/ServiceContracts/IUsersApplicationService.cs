using Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface IUsersApplicationService
    {
        Task<IActionResult> Create(UsersCreate users);
        Task<IActionResult> Read();
        Task<IActionResult> Update(Users users);
        Task<IActionResult> Delete(int id);
        
    }
}
