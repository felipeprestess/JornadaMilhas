using JornadaMilhas.Domain.Entities;

namespace JornadaMilhas.Application.Depoimentos.Queries.GetDepoimentos;
public class DepoimentoDto
{
    public int Id { get; set; }
    public string? Foto { get; set; }
    public string? Depoimento { get; set; }
    public string? NomeUsuario { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Depoimento, DepoimentoDto>();
        }
    }

}


