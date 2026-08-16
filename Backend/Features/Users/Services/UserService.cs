namespace Backend.Features.Users.Services;
using Backend.Features.Users.Interfaces;
using Backend.Features.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<UserEntity?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<UserEntity> AddAsync(UserEntity entity) => await _repository.AddAsync(entity);

    public async Task UpdateAsync(UserEntity entity) => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
