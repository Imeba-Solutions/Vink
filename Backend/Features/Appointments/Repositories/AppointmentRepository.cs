namespace Backend.Features.Appointments.Repositories;
using Backend.Features.Appointments.Interfaces;
using Backend.Features.Appointments.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAllAsync()
    {
        return await _context.Set<AppointmentEntity>().ToListAsync();
    }

    public async Task<AppointmentEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<AppointmentEntity>().FindAsync(id);
    }

    public async Task<AppointmentEntity> AddAsync(AppointmentEntity entity)
    {
        _context.Set<AppointmentEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(AppointmentEntity entity)
    {
        _context.Set<AppointmentEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<AppointmentEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
