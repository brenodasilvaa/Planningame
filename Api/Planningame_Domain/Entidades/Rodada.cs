using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planningame_Domain.Entidades
{
    public class Rodada : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }
        public required Guid PartidaId { get; set; }
        public required Partida Partida { get; set; }
        public ICollection<Jogador> Jogadores { get; set; } = [];
        public ICollection<Voto> Votos { get; set; } = [];
    }
}
