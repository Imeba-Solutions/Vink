namespace Backend.Features.Patients.Repositories;
using Backend.Features.Patients.Interfaces;
using Backend.Features.Patients.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PatientEntity>> GetAllAsync()
    {
        return await _context.Set<PatientEntity>().ToListAsync();
    }

    public async Task<PatientEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<PatientEntity>().FindAsync(id);
    }

    public async Task<PatientEntity> AddAsync(PatientEntity entity)
    {
        _context.Set<PatientEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(PatientEntity entity)
    {
        _context.Set<PatientEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<PatientEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
