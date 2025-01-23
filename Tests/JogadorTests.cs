using Bogus;
using NSubstitute;
using Planningame_Application.Services;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace PlanningGame_Tests
{
    public class JogadorTests
    {
        [Fact]
        public async Task Jogador_Criar_DeveCriarJogador()
        {
            var jogadorRepo = Substitute.For<IJogadorRepository>();
            var partidaRepo = Substitute.For<IPartidaRepository>();
            var votoRepo = Substitute.For<IVotoRepository>();
            var rodadaRepo = Substitute.For<IRodadaRepository>();
            var ufw = Substitute.For<IUnityOfWork>();

            var partidaId = Guid.NewGuid();
            var rodadaId = Guid.NewGuid();

            var partida = new Faker<Partida>()
                .RuleFor(c => c.Nome, f => f.Lorem.Text())
                .RuleFor(c => c.Id, partidaId).Generate(1).First();

            var rodada = new Faker<Rodada>()
                .RuleFor(c => c.Id, rodadaId).Generate(1).First();

            var jogador = new Faker<Jogador>()
                .RuleFor(c => c.PartidaId, partidaId).Generate(1).First();

            rodadaRepo.GetById(rodadaId, CancellationToken.None).Returns(rodada);
            partidaRepo.GetById(partidaId, CancellationToken.None).Returns(partida);
            partidaRepo.GetRodadaAtiva(partidaId, CancellationToken.None).Returns(rodada.Id);

            var jogadorService = new JogadoresService(jogadorRepo, partidaRepo, rodadaRepo, ufw);

            await jogadorService.Criar(jogador, CancellationToken.None);

            Assert.Contains(jogador.Rodadas, x => x.Id == rodadaId);
        }
    }
}
