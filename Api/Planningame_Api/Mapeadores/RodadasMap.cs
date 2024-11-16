using Mapster;
using Planningame_Api.Commands;
using Planningame_Api.Dtos;
using Planningame_Domain.Entidades;

namespace Planningame_Api.Mapeadores
{
    public static class RodadasMap
    {
        public static void Add()
        {
            TypeAdapterConfig<Rodada, RodadaInfoDto>
           .NewConfig()
           .Map(dest => dest.NumeroJogadores, src => src.Jogadores.Count)
           .Map(dest => dest.TodosVotaram, src => src.Jogadores.All(x => x.Votos.Any(x => src.Id == x.RodadaId)))
           .Map(dest => dest.Jogadores, src => src.Jogadores.Adapt<ICollection<RodadaJogadorInfoDto>>());

            TypeAdapterConfig<Jogador, RodadaJogadorInfoDto>
                .NewConfig()
                .Map(dest => dest.Votou, src => src.Votos.Any(x => src.Rodadas.Any(y => y.Id == x.RodadaId)));
        }
    }
}
