using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Application.Common.Interfaces;
using JornadaMilhas.Domain.Entities;

namespace JornadaMilhas.Application.Depoimentos.Commands.CreateDepoimento;

public record CreateDepoimentoCommand : IRequest<int>
{
    public string? Foto { get; init; }
    public string? Descricao { get; init; }
    public string? NomeUsuario { get; init; }
}

public class CreateDepoimentoCommandHandler : IRequestHandler<CreateDepoimentoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDepoimentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDepoimentoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Depoimento
        {
            Foto = request.Foto,
            Descricao = request.Descricao,
            NomeUsuario = request.NomeUsuario
        };

        _context.Depoimentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return entity.Id;
    }
}
