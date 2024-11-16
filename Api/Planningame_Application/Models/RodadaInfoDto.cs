namespace Planningame_Application.Models
{
    public class RodadaInfoDto
    {
        public int NumeroJogadores { get; set; }
        public bool TodosVotaram { get; set; }
        public required ICollection<RodadaJogadorInfoDto> JogadoresInfo { get; set; }
    }

    public class RodadaJogadorInfoDto
    {
        public required string Nome { get; set; }
        public required bool Votou { get; set; }
    }
}
