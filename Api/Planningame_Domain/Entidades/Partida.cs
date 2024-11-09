using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Entidades
{
    public class Partida : EntityBase
    {
        public required string Nome { get; set; }
        public required ICollection<Jogador> Jogadores { get; set; } = [];
        public required ICollection<Rodada> Rodadas{ get; set; } = [];
    }
}
