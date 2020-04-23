using System.Threading.Tasks;
using Moq;
using ScrobbleBot.Application.Interfaces;
using ScrobbleBot.Domain.Entities;
using ScrobbleBot.Infrastructure.Modules;
using Xunit;

namespace ScrobbleBot.Tests
{
    public class LastFmModuleTests
    {
        [Fact]
        public async Task GetUserProfileAsyncTest()
        {
            // Arrange
            var mock = new Mock<ILastFmService>();
            mock.Setup(lastFmService => lastFmService.GetProfileInfoAsync("kick1999")).ReturnsAsync(new UserProfile());
            var mock2 = new Mock<ICommandWebsocketService>();
            mock2.Setup(lastFmService => lastFmService.SendCommandAsync("kick1999", ""));
            LastFmModule service = new LastFmModule(mock.Object, mock2.Object);

            // Act
            await service.GetUserProfileCommandAsync("kick1999");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetProfileInfoAsync("kick1999"), Times.Exactly(1));
        }

        [Fact]
        public async Task GetArtistInfoAsyncTest()
        {
            // Arrange
            var mock = new Mock<ILastFmService>();
            mock.Setup(lastFmService => lastFmService.GetProfileInfoAsync("kick1999")).ReturnsAsync(new UserProfile());
            var mock2 = new Mock<ICommandWebsocketService>();
            mock2.Setup(lastFmService => lastFmService.SendCommandAsync("kick1999", ""));
            LastFmModule service = new LastFmModule(mock.Object, mock2.Object);

            // Act
            await service.GetArtistProfileCommandAsync("");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetArtistInfoAsync(""), Times.Exactly(1));
        }

        [Fact]
        public async Task GetRecentTracksAsyncTest()
        {
            // Arrange
            var mock = new Mock<ILastFmService>();
            mock.Setup(lastFmService => lastFmService.GetProfileInfoAsync("kick1999")).ReturnsAsync(new UserProfile());
            var mock2 = new Mock<ICommandWebsocketService>();
            mock2.Setup(lastFmService => lastFmService.SendCommandAsync("kick1999", ""));
            LastFmModule service = new LastFmModule(mock.Object, mock2.Object);

            // Act
            await service.GetRecentTracksAsync("");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetRecentTracksAsync(""), Times.Exactly(1));
        }

        [Fact]
        public async Task GetWeeklyChartAsyncTest()
        {
            // Arrange
            var mock = new Mock<ILastFmService>();
            mock.Setup(lastFmService => lastFmService.GetProfileInfoAsync("kick1999")).ReturnsAsync(new UserProfile());
            var mock2 = new Mock<ICommandWebsocketService>();
            mock2.Setup(lastFmService => lastFmService.SendCommandAsync("kick1999", ""));
            LastFmModule service = new LastFmModule(mock.Object, mock2.Object);

            // Act
            await service.GetWeeklyChartAsync("");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetWeeklyChartAsync(""), Times.Exactly(1));
        }
    }
}