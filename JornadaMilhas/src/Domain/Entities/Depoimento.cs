using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Domain.Entities;
public class Depoimento : BaseAuditableEntity
{
    public string? Foto { get; set; }
    public string? Descricao { get; set; }
    public string? NomeUsuario { get; set; }

}
