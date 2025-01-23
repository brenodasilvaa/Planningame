using Bogus;
using NSubstitute;
using Planningame_Application.Services;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace PlanningGame_Tests
{
    public class RodadaTests
    {
        [Fact]
        public async Task Rodada_CalcularVoto_DeveObterMedia()
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

            var votos = new Faker<Voto>().RuleFor(x => x.Valor, f => f.Random.Int()).Generate(5).AsQueryable();
            var mediaEsperada = votos.Select(x => x.Valor).Average();

            votoRepo.GetByRodadaId(rodadaId, CancellationToken.None).Returns(votos);

            var rodadaService = new RodadaService(rodadaRepo, jogadorRepo, votoRepo, ufw);

            var calculoVotosResultado = await rodadaService.CalcularVotos(rodadaId, CancellationToken.None);

            Assert.True(calculoVotosResultado == mediaEsperada);
        }
    }
}
