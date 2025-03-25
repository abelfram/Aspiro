using Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
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
            _applicationService = applicationService;
        }
        #endregion

        #region .: Public Methods :.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(TasksCreate tasks)
        {
            var result = await _applicationService.Create(tasks);
            return result;
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> Read()
        {
            var result = await _applicationService.Read();
            return result;
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(Tasks tasks)
        {
            var result = await _applicationService.Update(tasks);
            return result;
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _applicationService.Delete(id);
            return result;
        }
        #endregion



    }
}
