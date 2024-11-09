namespace Planningame_Api.Commands
{
    public class CreateVotoCommand
    {
        public required int Valor { get; set; }
        public required Guid JogadorId { get; set; }
        public required Guid RodadaId { get; set; }
        public required DateTime DataDoVoto { get; set; } = DateTime.Now;
    }
}
