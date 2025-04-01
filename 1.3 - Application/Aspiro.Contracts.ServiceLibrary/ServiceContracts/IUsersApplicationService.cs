using Aspiro.Contracts.ServiceLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.Contracts.ServiceLibrary.ServiceContracts
{
    public interface IUsersApplicationService
    {
        Task<IActionResult> Create(UsersInput users);
        Task<IActionResult> Read();
        Task<IActionResult> Update(UsersInput users, int id);
        Task<IActionResult> Delete(int id);
        
    }
}
