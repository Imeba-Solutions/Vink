namespace Backend.Features.Patients.Interfaces;
using Backend.Features.Patients.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPatientService
{
    Task<IEnumerable<PatientEntity>> GetAllAsync();
    Task<PatientEntity?> GetByIdAsync(int id);
    Task<PatientEntity> AddAsync(PatientEntity entity);
    Task UpdateAsync(PatientEntity entity);
    Task DeleteAsync(int id);
}
