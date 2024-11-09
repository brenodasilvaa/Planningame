using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Entidades
{
    public class Jogador : EntityBase
    {
        public required string Nome { get; set; }
        public required Guid PartidaId { get; set; }
        public required Partida Partida { get; set; }
        public required ICollection<Rodada> Rodadas { get; set; }
        public required ICollection<Voto> Votos { get; set; }
    }
}
