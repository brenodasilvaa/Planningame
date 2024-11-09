namespace Planningame_Api.Commands
{
    public class CreateJogadorCommand
    {
        public required string Nome { get; set; }
        public required Guid PartidaId { get; set; }
    }
}
