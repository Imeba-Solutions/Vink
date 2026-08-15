namespace Backend.Features.Users.Interfaces;
using Backend.Features.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task<UserEntity?> GetByIdAsync(int id);
    Task<UserEntity> AddAsync(UserEntity entity);
    Task UpdateAsync(UserEntity entity);
    Task DeleteAsync(int id);
}
