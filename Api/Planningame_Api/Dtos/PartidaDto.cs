namespace Planningame_Api.Dtos
{
    public class PartidaDto
    {
        public required Guid Id { get; set; }
        public required ICollection<JogadorDto> Jogadores { get; set; }
        public required ICollection<RodadaDto> Rodadas { get; set; }
    }
}
