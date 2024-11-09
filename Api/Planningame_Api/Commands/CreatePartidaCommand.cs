namespace Planningame_Api.Commands
{
    public class CreatePartidaCommand
    {
        public required string Nome { get; set; }
        public required CreateJogadorPartidaCommand Jogador { get; set; }
    }
}
