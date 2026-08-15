namespace Backend.Features.Shared;

public interface ISoftDelete
{
    DateTime? DeletedAt { get; set; }
}
