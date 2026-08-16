namespace Backend.Features.Roles.Interfaces;
using Backend.Features.Roles.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoleService
{
    Task<IEnumerable<RoleEntity>> GetAllAsync();
    Task<RoleEntity?> GetByIdAsync(int id);
    Task<RoleEntity> AddAsync(RoleEntity entity);
    Task UpdateAsync(RoleEntity entity);
    Task DeleteAsync(int id);
}
