using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspiro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        #region .: Private Variables :.
        private readonly ITasksApplicationService _applicationService;
        #endregion

        #region .: Constructor :.
        public TasksController(ITasksApplicationService applicationService)
        {
            applicationService = _applicationService;   
        }
        #endregion

        #region .: Public Methods :.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            var result = await _applicationService.Create();
            return result;
        }
        #endregion



    }
}
