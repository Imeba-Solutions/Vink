namespace Backend.Features.MedicalRecords.Services;
using Backend.Features.MedicalRecords.Interfaces;
using Backend.Features.MedicalRecords.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IMedicalRecordRepository _repository;

    public MedicalRecordService(IMedicalRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MedicalRecordEntity>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<MedicalRecordEntity?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<MedicalRecordEntity> AddAsync(MedicalRecordEntity entity) => await _repository.AddAsync(entity);

    public async Task UpdateAsync(MedicalRecordEntity entity) => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
