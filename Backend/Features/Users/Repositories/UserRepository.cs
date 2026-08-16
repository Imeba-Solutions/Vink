namespace Backend.Features.Users.Repositories;
using Backend.Features.Users.Interfaces;
using Backend.Features.Users.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Set<UserEntity>().ToListAsync();
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<UserEntity>().FindAsync(id);
    }

    public async Task<UserEntity> AddAsync(UserEntity entity)
    {
        _context.Set<UserEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        _context.Set<UserEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<UserEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
