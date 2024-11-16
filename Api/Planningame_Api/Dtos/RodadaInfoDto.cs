namespace Planningame_Api.Dtos
{
    public class RodadaInfoDto
    {
        public required int NumeroJogadores { get; set; }
        public required bool TodosVotaram { get; set; }
        public required ICollection<RodadaJogadorInfoDto> Jogadores { get; set; }
    }

    public class RodadaJogadorInfoDto
    {
        public required string Nome { get; set; }
        public required bool Votou { get; set; }
    }
}
