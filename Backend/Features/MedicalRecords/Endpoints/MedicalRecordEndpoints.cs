namespace Backend.Features.MedicalRecords.Endpoints;
using Backend.Features.MedicalRecords.Interfaces;
using Backend.Features.MedicalRecords.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class MedicalRecordEndpoints
{
    public static void MapMedicalRecordEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/medicalrecords").WithTags("MedicalRecords");

        group.MapGet("/", async (IMedicalRecordService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id}", async (int id, IMedicalRecordService service) =>
        {
            var entity = await service.GetByIdAsync(id);
            return entity is not null ? Results.Ok(entity) : Results.NotFound();
        });

        group.MapPost("/", async (MedicalRecordEntity entity, IMedicalRecordService service) =>
        {
            var created = await service.AddAsync(entity);
            return Results.Created($"/api/medicalrecords/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, MedicalRecordEntity entity, IMedicalRecordService service) =>
        {
            if (id != entity.Id) return Results.BadRequest();
            await service.UpdateAsync(entity);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, IMedicalRecordService service) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
