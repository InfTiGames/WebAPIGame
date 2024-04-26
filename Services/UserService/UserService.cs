using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Services.UserService {
    public class UserService : IUserService {

        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public async Task<bool> AddUser(UserDTO user, CancellationToken cancellationToken) {
            var result = await _dataContext.Users.AnyAsync(u => u.Username == user.Username, cancellationToken);
            if(result is true) {
                return false;
            }
            var newUser = new User {
                Username = user.Username,
                Password = user.Password
            };

            await _dataContext.Users.AddAsync(newUser, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteUser(int id, CancellationToken cancellationToken) {
            var result = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if(result is null) {
                return false;
            }
            _dataContext.Users.Remove(result);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken) {
            return await _dataContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User> GetUserById(int id, CancellationToken cancellationToken) {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<bool> UpdateUser(int id, UserDTO user, CancellationToken cancellationToken) {
            var result = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if(result is null) {
                return false;
            }

            result.Username = user.Username;
            result.Password = user.Password;

            await _dataContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}