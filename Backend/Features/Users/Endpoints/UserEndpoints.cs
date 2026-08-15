namespace Backend.Features.Users.Endpoints;
using Backend.Features.Users.Interfaces;
using Backend.Features.Users.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users").WithTags("Users");

        group.MapGet("/", async (IUserService service) =>
        {
            return Results.Ok(await service.GetAllAsync());
        });

        group.MapGet("/{id}", async (int id, IUserService service) =>
        {
            var entity = await service.GetByIdAsync(id);
            return entity is not null ? Results.Ok(entity) : Results.NotFound();
        });

        group.MapPost("/", async (UserEntity entity, IUserService service) =>
        {
            var created = await service.AddAsync(entity);
            return Results.Created($"/api/users/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, UserEntity entity, IUserService service) =>
        {
            if (id != entity.Id) return Results.BadRequest();
            await service.UpdateAsync(entity);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, IUserService service) =>
        {
            await service.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
