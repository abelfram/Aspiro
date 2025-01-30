using Aspiro.DB.Infrastructure.BoundedContexts;
using Aspiro.Library.Entities;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using DTO = Aspiro.Contracts.ServiceLibrary.DTO;

namespace Aspiro.DB.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AspiroDBContext _context;

        public UsersRepository(AspiroDBContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Create(DTO.Users users)
        {
            try
            {
                var newUser = new Users{ Name = users.Name , Dni = users.Dni};

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

        public async Task<IActionResult> Update(string oldDni, DTO.Users users)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Dni == oldDni);

                if (existingUser == null)
                {
                    return new NotFoundObjectResult($"User with DNI '{oldDni}' not found");
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

        public async Task<IActionResult> Delete(string dni)
        {
            try
            {
                var deletedUser = await _context.Users.FirstOrDefaultAsync(x => x.Dni == dni);

                if (deletedUser == null)
                {
                    return new NotFoundObjectResult($"User with Dni '{dni}' not found");
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
