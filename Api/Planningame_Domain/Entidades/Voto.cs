using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Entidades
{
    public class Voto : EntityBase
    {
        public int Valor { get; set; }
        public Guid JogadorId { get; set; }
        public Guid RodadaId { get; set; }
        public required Jogador Jogador { get; set; }
        public required Rodada Rodada { get; set; }
        public required DateTime DataDoVoto { get; set; } = DateTime.UtcNow;
    }
}
