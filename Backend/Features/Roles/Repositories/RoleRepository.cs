namespace Backend.Features.Roles.Repositories;
using Backend.Features.Roles.Interfaces;
using Backend.Features.Roles.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoleEntity>> GetAllAsync()
    {
        return await _context.Set<RoleEntity>().ToListAsync();
    }

    public async Task<RoleEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<RoleEntity>().FindAsync(id);
    }

    public async Task<RoleEntity> AddAsync(RoleEntity entity)
    {
        _context.Set<RoleEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(RoleEntity entity)
    {
        _context.Set<RoleEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<RoleEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
