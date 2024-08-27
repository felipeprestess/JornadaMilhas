using JornadaMilhas.Application.Common.Interfaces;

namespace JornadaMilhas.Application.Depoimentos.Commands.DeleteDepoimento;
public record DeleteDepoimentoCommand(int Id) : IRequest;

public class DeleteDepoimentoCommandHandler : IRequestHandler<DeleteDepoimentoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDepoimentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task  Handle(DeleteDepoimentoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Depoimentos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Depoimentos.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
