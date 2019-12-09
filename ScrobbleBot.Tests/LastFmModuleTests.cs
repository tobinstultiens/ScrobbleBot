using System.Threading.Tasks;
using Moq;
using ScrobbleBot.Application.Interfaces;
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
            mock.Setup(lastFmService => lastFmService.GetProfileInfoAsync(""));
            ILastFmService service = mock.Object;

            // Act
            await service.GetProfileInfoAsync("");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetProfileInfoAsync(""), Times.Exactly(1));
        }

        [Fact]
        public async Task GetArtistInfoAsyncTest()
        {
            // Arrange
            var mock = new Mock<ILastFmService>();
            mock.Setup(lastFmService => lastFmService.GetArtistInfoAsync(""));
            ILastFmService service = mock.Object;

            // Act
            await service.GetArtistInfoAsync("");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetArtistInfoAsync(""), Times.Exactly(1));
        }

        [Fact]
        public async Task GetRecentTracksAsyncTest()
        {
            // Arrange
            var mock = new Mock<ILastFmService>();
            mock.Setup(lastFmService => lastFmService.GetRecentTracksAsync(""));
            ILastFmService service = mock.Object;

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
            mock.Setup(lastFmService => lastFmService.GetWeeklyChartAsync(""));
            ILastFmService service = mock.Object;

            // Act
            await service.GetWeeklyChartAsync("");

            // Assert
            mock.Verify(lastFmService => lastFmService.GetWeeklyChartAsync(""), Times.Exactly(1));
        }
    }
}