using JornadaMilhas.Application.Common.Interfaces;

namespace JornadaMilhas.Application.Depoimentos.Commands.UpdateDepoimento;
public record UpdateDepoimentoCommand : IRequest
{
    public int Id { get; init; }
    public string? Foto { get; set; }
    public string? Descricao { get; set; }
    public string? NomeUsuario{ get; set; }

    public class UpdateDepoimentoCommandHandler : IRequestHandler<UpdateDepoimentoCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDepoimentoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateDepoimentoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Depoimentos
                .FindAsync(new object[] { request.Id }, cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            entity.Descricao = request.Descricao;
            entity.Foto = request.Foto;
            entity.NomeUsuario = request.NomeUsuario;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
