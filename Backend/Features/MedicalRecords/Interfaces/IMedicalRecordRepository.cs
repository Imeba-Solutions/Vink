namespace Backend.Features.MedicalRecords.Interfaces;
using Backend.Features.MedicalRecords.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMedicalRecordRepository
{
    Task<IEnumerable<MedicalRecordEntity>> GetAllAsync();
    Task<MedicalRecordEntity?> GetByIdAsync(int id);
    Task<MedicalRecordEntity> AddAsync(MedicalRecordEntity entity);
    Task UpdateAsync(MedicalRecordEntity entity);
    Task DeleteAsync(int id);
}
