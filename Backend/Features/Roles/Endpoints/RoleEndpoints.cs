namespace Backend.Features.Roles.Endpoints;
using Backend.Features.Roles.Interfaces;
using Backend.Features.Roles.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/roles").WithTags("Roles");

        group.MapGet("/", async (IRoleService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id}", async (int id, IRoleService service) =>
        {
            var entity = await service.GetByIdAsync(id);
            return entity is not null ? Results.Ok(entity) : Results.NotFound();
        });

        group.MapPost("/", async (RoleEntity entity, IRoleService service) =>
        {
            var created = await service.AddAsync(entity);
            return Results.Created($"/api/roles/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, RoleEntity entity, IRoleService service) =>
        {
            if (id != entity.Id) return Results.BadRequest();
            await service.UpdateAsync(entity);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, IRoleService service) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
