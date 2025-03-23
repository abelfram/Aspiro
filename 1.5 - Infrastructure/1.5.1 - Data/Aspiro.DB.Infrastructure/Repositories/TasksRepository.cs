using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;
using Aspiro.DB.Infrastructure.BoundedContexts;
using AutoMapper;
using Aspiro.Library.Entities;

namespace Aspiro.DB.Infrastructure.Repositories
{
    public class TasksRepository : ITasksRepository
    {

        private AspiroDBContext _context;
        private IMapper _mapper;

        public TasksRepository(AspiroDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Create(DTO.Tasks tasks)
        {
            try
            {
                var newTask = _mapper.Map<Tasks>(tasks);
                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();
                return new OkObjectResult(new { message = $"Task '{tasks.Name}' created succesfully with Id {tasks.Id}" });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"An error has ocurred: {ex.Message}" });
            }
        }

        public Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Read()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }
    }
}
