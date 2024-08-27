using JornadaMilhas.Domain.Entities;

namespace JornadaMilhas.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Depoimento> Depoimentos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
