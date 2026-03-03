using System.Text.Json;
using Parcel_Service.Enum;
using Parcel_Service.Packages;
using Parcel_Service.Thread;

namespace ParcelService.Tests
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
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();

            await Assert.ThrowsAsync<JsonException>(() => processor.ProcessPackagesAsync(inputPath, outputPath));
        }

        [Fact]
        public async Task ProcessPackagesAsync_ValidJson_ReturnsPackages()
        {
            string inputPath = "valid.json";
            string outputPath = "output.txt";

            var dtos = new List<PackageDto>
            {
                new PackageDto { id = 1, name = "Doc", description = "Test", type = "Documents", weight = 1.0 },
                new PackageDto { id = 2, name = "Box", description = "Heavy", type = "HeavyPackage", weight = 50.0 }
            };

            string json = JsonSerializer.Serialize(dtos);
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();

            var result = await processor.ProcessPackagesAsync(inputPath, outputPath);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.type == PackageType.Documents);
            Assert.Contains(result, p => p.type == PackageType.HeavyPackage);
        }

        [Fact]
        public async Task ProcessPackagesAsync_NullValues_ReturnsPackageWithNulls()
        {
            string inputPath = "nulls.json";
            string outputPath = "output.txt";

            var dtos = new List<PackageDto>
            {
                new PackageDto { id = 10, name = null, description = null, type = "Documents", weight = 0 }
            };

            string json = JsonSerializer.Serialize(dtos);
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();

            var result = await processor.ProcessPackagesAsync(inputPath, outputPath);

            Assert.Single(result);
            Assert.Equal(10, result[0].id);
            Assert.Null(result[0].name);
            Assert.Null(result[0].description);
            Assert.Equal(PackageType.Documents, result[0].type);
        }
    }
}