namespace Backend.Features.Patients.Endpoints;
using Backend.Features.Patients.Interfaces;
using Backend.Features.Patients.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class PatientEndpoints
{
    public static void MapPatientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/patients").WithTags("Patients");

        group.MapGet("/", async (IPatientService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id}", async (int id, IPatientService service) =>
        {
            var entity = await service.GetByIdAsync(id);
            return entity is not null ? Results.Ok(entity) : Results.NotFound();
        });

        group.MapPost("/", async (PatientEntity entity, IPatientService service) =>
        {
            var created = await service.AddAsync(entity);
            return Results.Created($"/api/patients/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, PatientEntity entity, IPatientService service) =>
        {
            if (id != entity.Id) return Results.BadRequest();
            await service.UpdateAsync(entity);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, IPatientService service) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
