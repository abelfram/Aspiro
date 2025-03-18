using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
using System.Web.Http;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.AspNetCore.Mvc;
using Aspiro.Contracts.ServiceLibrary.DTO;

namespace Aspiro.Impl.ServiceLibrary.Implementations
{
    public class AspiroApplicationService : IAspiroApplicationService
    {
        #region .: Private Methods :.
        private readonly IUsersRepository _userRepository;
        #endregion

        #region .: Constructor :.
        public AspiroApplicationService(IUsersRepository usersRepository)
        {
            _userRepository = usersRepository;
        }
        #endregion

        #region .: Public Methods :.

        public Task<IActionResult> Create(Users users)
        {
            var result = _userRepository.Create(users);
            return result;
        }

        public Task<IActionResult> Read()
        {
            var result = _userRepository.Read();
            return result;
        }

        public Task<IActionResult> Update(Users users)
        {
            var result = _userRepository.Update(users);
            return result;
        }

        public Task<IActionResult> Delete(int Id)
        {
            var result = _userRepository.Delete(Id);
            return result;
        }

        
        #endregion
    }
}
