using Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {

        #region .: Private Variables :.
        private readonly IAspiroApplicationService _aspiroApplicationService;
        #endregion

        #region .: Constructor :.
        public UserController(IAspiroApplicationService aspiroApplicationService)
        {
            _aspiroApplicationService = aspiroApplicationService;
        }

        #endregion

        #region .: Public Methods :.

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Users users)
        {
            var result = await _aspiroApplicationService.Create(users);
            return result;
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> Read()
        {
            var result = await _aspiroApplicationService.Read();
            return result;
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(Users users)
        {
            var result = await _aspiroApplicationService.Update(users);
            return result;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _aspiroApplicationService.Delete(id);
            return result;
        }

        
        #endregion
    }
}
