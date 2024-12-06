using Planningame_Application.Interfaces;
using Planningame_Application.Services;
using PlanningGame_Tests.Fakers;
using Xunit;

namespace PlanningGame_Tests
{
    public class JogadorTests
    {
        [Fact]
        public async Task Jogador_CriarJogador_DeveInserir()
        {
            var jogadorService = new JogadoresService(new JogadoresRepoFaker(), )
        }
    }
}
