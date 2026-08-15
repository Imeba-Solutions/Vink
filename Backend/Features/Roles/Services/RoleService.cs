namespace Backend.Features.Roles.Services;
using Backend.Features.Roles.Interfaces;
using Backend.Features.Roles.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RoleEntity>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<RoleEntity?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<RoleEntity> AddAsync(RoleEntity entity) => await _repository.AddAsync(entity);

    public async Task UpdateAsync(RoleEntity entity) => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
