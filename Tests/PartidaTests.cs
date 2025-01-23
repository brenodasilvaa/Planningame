using Bogus;
using NSubstitute;
using Planningame_Application.Services;
using Planningame_Domain.Entidades;
using Planningame_Domain.Interfaces;
using Planningame_Domain.Interfaces.Repositorios;

namespace PlanningGame_Tests
{
    public class PartidaTests
    {
        [Fact]
        public async Task Partida_DeveObter()
        {
            var jogadorRepo = Substitute.For<IJogadorRepository>();
            var partidaRepo = Substitute.For<IPartidaRepository>();
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

            partidaRepo.GetRodadaAtiva(partidaId, CancellationToken.None).Returns(rodadaId);
            partidaRepo.GetById(partidaId, CancellationToken.None).Returns(partida);
            rodadaRepo.GetById(rodadaId, CancellationToken.None).Returns(rodada);

            var partidaService = new PartidaService(partidaRepo, ufw);

            var partidaAssert = await partidaService.GetById(partidaId, CancellationToken.None);

            Assert.True(partidaAssert.Nome == partida.Nome);
        }

        [Fact]
        public async Task Partida_DeveObterRodadaAtiva()
        {
            var jogadorRepo = Substitute.For<IJogadorRepository>();
            var partidaRepo = Substitute.For<IPartidaRepository>();
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

            partidaRepo.GetRodadaAtiva(partidaId, CancellationToken.None).Returns(rodadaId);
            partidaRepo.GetById(partidaId, CancellationToken.None).Returns(partida);
            rodadaRepo.GetById(rodadaId, CancellationToken.None).Returns(rodada);

            var partidaService = new PartidaService(partidaRepo, ufw);

            var partidaAssert = await partidaRepo.GetRodadaAtiva(partidaId, CancellationToken.None);

            Assert.True(partidaAssert == rodadaId);
        }
    }
}
