using System;
using System.Collections.Generic;
using System.Text;
using Cartera.DataAccess;
using Cartera.DTO;
using Cartera.Entities;
using System.Linq;
using System.Threading.Tasks;


namespace Cartera.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _personProfileRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository personProfileRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _personProfileRepository = personProfileRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(UserDto u)
        {
            Account account = new Account();
            User user = new User
            {          
                    Name=u.Name,
                    Address = u.Address,
                    Phone = u.Phone,
                    Email = u.Email,
                    Password = u.Password,
            };

            try
            {
                await _personProfileRepository.Create(user); ; ; ;
                account.User = user.Email;
                account.Password = user.Password;
                await _unitOfWork.CompleteAsync();
                account.Idf = user.Id;
                account.RolId = 0;
                await _accountRepository.AddAsyn(account);
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _personProfileRepository.Delete(id);
        }

        public async Task<ICollection<UserDto>> GetCollection()
        {
            var collection = await _personProfileRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(Bill => new UserDto
                {
                    Name=Bill.Name,
                    Address = Bill.Address,
                    Phone = Bill.Phone,
                    Email = Bill.Email,
                    Password = Bill.Password,


                }).ToList();
        }

        public async Task<ResponseDto<UserDto>> GetItem(int id)
        {
            var response = new ResponseDto<UserDto>();
            var Bill = await _personProfileRepository.GetItem(id);

            if (Bill == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new UserDto
            {
                Name=Bill.Name,
                Address = Bill.Address,
                Phone = Bill.Phone,
                Email = Bill.Email,
                Password = Bill.Password,
            };

            response.Success = true;

            return response;
        }
    

        public async Task Update(int id, UserDto u)
        {
            await _personProfileRepository.Update(new Entities.User
            {
                Id = id,
                Name=u.Name,
                Address = u.Address,
                Phone = u.Phone,
                Email = u.Email,
                Password = u.Password,


            });
        }
    }
}
