using Aspiro.DB.Infrastructure.BoundedContexts;
using Aspiro.Library.Entities;
using Aspiro.Library.InfrastructureContracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTO = Aspiro.Contracts.ServiceLibrary.DTO;

namespace Aspiro.DB.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AspiroDBContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(AspiroDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Create(DTO.Users users)
        {
            try
            {
                var newUser = _mapper.Map<Users>(users);
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return new OkObjectResult($"User '{users.Name}' created successfully with dni {users.Dni}.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"An error has ocurred: {ex.Message}" );
            }
        }

        public async Task<IActionResult> Read()
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"An error has ocurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> Update(DTO.Users users)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == users.Id);

                if (existingUser == null)
                {
                    return new NotFoundObjectResult($"User with Id '{users.Id}' not found");
                }

                existingUser.Name = users.Name;
                existingUser.Dni = users.Dni;

                await _context.SaveChangesAsync();

                return new OkObjectResult($"User {users.Name} updated correctly");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"An error has ocurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (deletedUser == null)
                {
                    return new NotFoundObjectResult($"User with id '{id}' not found");
                }
                _context.Users.Remove(deletedUser);

                await _context.SaveChangesAsync();

                return new OkObjectResult($"{deletedUser.Name} deleted");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Could not delete {ex.Message}");
            }
        }
    }
}
