using System.Text.Json;
using Moq;
using Parcel_Service.Thread;
using Parcel_Service.Interfaces;

namespace Parcel_Service.Tests
{
    public class UnitTestProcessor
    {
        [Fact]
        public async Task ProcessPackagesAsync_EmptyJson_ReturnsEmptyList()
        {
            string inputPath = "empty.json";
            string outputPath = "output.txt";

            string json = "[]";
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();
            
            var result = await processor.ProcessPackagesAsync(inputPath, outputPath);
            
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task ProcessPackagesAsync_InvalidJson_ThrowsException()
        {
            string inputPath = "invalid.json";
            string outputPath = "output.txt";

            string json = "not a valid json";
            var processor = new PackageProcessor();
            
            await Assert.ThrowsAsync<JsonException>(() => processor.ProcessPackagesAsync(inputPath, outputPath));
        }
    }
}
