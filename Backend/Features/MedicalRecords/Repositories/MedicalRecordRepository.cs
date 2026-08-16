namespace Backend.Features.MedicalRecords.Repositories;
using Backend.Features.MedicalRecords.Interfaces;
using Backend.Features.MedicalRecords.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MedicalRecordRepository : IMedicalRecordRepository
{
    private readonly AppDbContext _context;

    public MedicalRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MedicalRecordEntity>> GetAllAsync()
    {
        return await _context.Set<MedicalRecordEntity>().ToListAsync();
    }

    public async Task<MedicalRecordEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<MedicalRecordEntity>().FindAsync(id);
    }

    public async Task<MedicalRecordEntity> AddAsync(MedicalRecordEntity entity)
    {
        _context.Set<MedicalRecordEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(MedicalRecordEntity entity)
    {
        _context.Set<MedicalRecordEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<MedicalRecordEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
