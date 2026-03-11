using System.Text.Json;
using Parcel_Service.Enum;
using Parcel_Service.Packages;
using Parcel_Service.Processors;

namespace ParcelService.Tests
{
    public class PackageProcessorTests
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
            string inputPath = "valid_complete.json";
            string outputPath = "output.txt";

            var dtos = new List<PackageDto>
            {
                new PackageDto { Id = 1, Name = "Laptop", Description = "Electronic", type = "Documents", Weight = 2.5 }
            };

            string json = JsonSerializer.Serialize(dtos);
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();

            var result = await processor.ProcessPackagesAsync(inputPath, outputPath);

            Assert.NotNull(result);
            Assert.Equal("Laptop", result[0].Name);
        }

        [Fact]
        public async Task ProcessPackagesAsync_NullValues_ReturnsPackageWithNulls()
        {
            string inputPath = "nulls.json";
            string outputPath = "output.txt";

            var dtos = new List<PackageDto>
            {
                new PackageDto { Id = 10, Name = null, Description = null, type = "Documents", Weight = 0 }
            };

            string json = JsonSerializer.Serialize(dtos);
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();

            var result = await processor.ProcessPackagesAsync(inputPath, outputPath);

            Assert.Empty(result);
            
        }
        [Fact]
        public async Task ProcessPackagesAsync_WhiteSpaceValues_ShouldIgnorePackage()
        {
            string inputPath = "whitespace.json";
            string outputPath = "output.txt";

            var dtos = new List<PackageDto>
            {
                new PackageDto { Id = 20, Name = "   ", Description = "", type = "Documents", Weight = 1.0 }
            };

            string json = JsonSerializer.Serialize(dtos);
            await File.WriteAllTextAsync(inputPath, json);

            var processor = new PackageProcessor();
            var result = await processor.ProcessPackagesAsync(inputPath, outputPath);
            
            Assert.Empty(result);
        }
        
    }
}