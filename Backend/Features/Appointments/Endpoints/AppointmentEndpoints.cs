namespace Backend.Features.Appointments.Endpoints;
using Backend.Features.Appointments.Interfaces;
using Backend.Features.Appointments.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class AppointmentEndpoints
{
    public static void MapAppointmentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/appointments").WithTags("Appointments");

        group.MapGet("/", async (IAppointmentService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id}", async (int id, IAppointmentService service) =>
        {
            var entity = await service.GetByIdAsync(id);
            return entity is not null ? Results.Ok(entity) : Results.NotFound();
        });

        group.MapPost("/", async (AppointmentEntity entity, IAppointmentService service) =>
        {
            var created = await service.AddAsync(entity);
            return Results.Created($"/api/appointments/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, AppointmentEntity entity, IAppointmentService service) =>
        {
            if (id != entity.Id) return Results.BadRequest();
            await service.UpdateAsync(entity);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, IAppointmentService service) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
