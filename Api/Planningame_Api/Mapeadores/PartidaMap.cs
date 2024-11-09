using Mapster;
using Planningame_Api.Commands;
using Planningame_Domain.Entidades;

namespace Planningame_Api.Mapeadores
{
    public static class PartidaMap
    {
        public static void Add()
        {
            TypeAdapterConfig<CreatePartidaCommand, Partida>
           .NewConfig()
           .Map(dest => dest.Jogadores, src => new List<Jogador> { src.Jogador.Adapt<Jogador>() });
        }
    }
}
