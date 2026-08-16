namespace Backend.Features.Patients.Services;
using Backend.Features.Patients.Interfaces;
using Backend.Features.Patients.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PatientEntity>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<PatientEntity?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<PatientEntity> AddAsync(PatientEntity entity) => await _repository.AddAsync(entity);

    public async Task UpdateAsync(PatientEntity entity) => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
