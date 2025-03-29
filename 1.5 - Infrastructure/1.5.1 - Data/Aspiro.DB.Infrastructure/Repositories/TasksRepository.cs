using DTO = Aspiro.Contracts.ServiceLibrary.DTO;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;
using Aspiro.DB.Infrastructure.BoundedContexts;
using AutoMapper;
using Aspiro.Library.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Create(DTO.TasksCreate tasks)
        {
            try
            {
                var newTask = _mapper.Map<Tasks>(tasks);
                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();
                return new OkObjectResult(new { message = $"Task '{tasks.Name}' created" });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"An error has ocurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> Read()
        {
            try
            {
                var tasks = await _context.Tasks.ToListAsync();
                return new OkObjectResult(tasks);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"An error has ocurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> Update(DTO.Tasks updatedTask)
        {
            try
            {
                var existingTask = _context.Tasks.FirstOrDefault(x => x.Id == updatedTask.Id);

                if (existingTask == null)
                {
                    return new NotFoundObjectResult(new { message = $"Task not found" });
                }

                existingTask.Name = updatedTask.Name;
                existingTask.Description = updatedTask.Description;

                await _context.SaveChangesAsync();

                return new OkObjectResult(new { message = $"Task with id: '{existingTask.Id}' updated correctly" });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"An error has ocurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var taskToDelete = _context.Tasks.FirstOrDefault(x => x.Id == id);

                if (taskToDelete == null)
                {
                    return new NotFoundObjectResult(new { message = $"Task not found" });
                }

                _context.Tasks.Remove(taskToDelete);

                await _context.SaveChangesAsync();

                return new OkObjectResult(new { message = $"Task '{taskToDelete.Name}' deleted" });

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"An error has ocurred: {ex.Message}" });
            }
        }

    }
}
