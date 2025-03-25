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

        #region .: Public Methods :.
        public async Task<IActionResult> Create(DTO.UsersCreate users)
        {
            try
            {
                if (await DniExists(users.Dni)) 
                    return new ConflictObjectResult(new { message = $"Dni '{users.Dni}' already exists" });
                
                else if (await EmailExists(users.Email)) 
                    return new ConflictObjectResult(new { message = $"Email '{users.Email}' already exists" });

                var newUser = _mapper.Map<Users>(users);
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return new OkObjectResult(new { message = $"User '{users.Name}' created successfully with dni {users.Dni}." });
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
                var users = await _context.Users.ToListAsync();

                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"An error has ocurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> Update(DTO.Users users)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == users.Id);

                if (existingUser == null)
                {
                    return new NotFoundObjectResult(new { message = $"User with Id '{users.Id}' not found" });
                }

                existingUser.Name = users.Name;
                existingUser.Dni = users.Dni;

                await _context.SaveChangesAsync();

                return new OkObjectResult(new { message = $"User {users.Name} updated correctly" });
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
                var deletedUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (deletedUser == null)
                {
                    return new NotFoundObjectResult(new { message = $"User with id '{id}' not found" });
                }
                _context.Users.Remove(deletedUser);

                await _context.SaveChangesAsync();

                return new OkObjectResult(new { message = $"{deletedUser.Name} deleted" });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = $"Could not delete {ex.Message}" });
            }
        }
        #endregion

        #region .: private Methods :.

        public async Task<bool> DniExists(string dni)
        {
            return await _context.Users.AnyAsync(u => u.Dni == dni);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        #endregion
    }
}
