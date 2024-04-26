using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Services.UserService {
    public interface IUserService {

        Task<List<User>> GetAllUsers(CancellationToken cancellationToken);

        Task<User> GetUserById(int id, CancellationToken cancellationToken);

        Task<bool> AddUser(UserDTO user, CancellationToken cancellationToken);

        Task<bool> UpdateUser(int id, UserDTO user, CancellationToken cancellationToken);

        Task<bool> DeleteUser(int id, CancellationToken cancellationToken);
    }
}