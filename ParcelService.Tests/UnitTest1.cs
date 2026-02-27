using Parcel_Service.Factory;
using Parcel_Service.Packages;
using Parcel_Service.Enum;

namespace Parcel_Service.Tests
{
    public class PackageFactoryTests
    {
        [Fact]
        public void CreatePackage_Documents_ReturnsDocumentsPackage()
        {
            var dto = new PackageDto
            {
                id = 1,
                name = "Doc1",
                description = "Important papers",
                type = "Documents",
                weight = 0.5
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.Documents, package.type);
            Assert.Equal(dto.id, package.id);
            Assert.Equal(dto.name, package.name);
            Assert.Equal(dto.description, package.description);
            Assert.Equal(dto.weight, package.weight);
        }
        [Fact]
        public void CreatePackage_HeavyPackage_ReturnsHeavyPackage()
        {
            var dto = new PackageDto
            {
                id = 2,
                name = "Box",
                description = "Heavy box",
                type = "HeavyPackage",
                weight = 100.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.HeavyPackage, package.type);
        }
        [Fact]
        public void CreatePackage_SmallPackage_ReturnsSmallPackage()
        {
            var dto = new PackageDto
            {
                id = 3,
                name = "Gift",
                description = "Small gift",
                type = "SmallPackage",
                weight = 1.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.SmallPackage, package.type);
        }
        [Fact]
        public void CreatePackage_InvalidType_ReturnsNull()
        {
            var dto = new PackageDto
            {
                id = 4,
                name = "Unknown",
                description = "Invalid type",
                type = "InvalidType",
                weight = 2.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.Null(package);
        }
        
        [Fact]
        public void CreatePackage_NullValues_StillCreatesPackage()
        {
            var dto = new PackageDto
            {
                id = 6,
                name = null,
                description = null,
                type = "Documents",
                weight = 0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.Documents, package.type);
            Assert.Null(package.name);
            Assert.Null(package.description);
        }
        [Fact]
        public void CreatePackage_ExtremeWeight_ReturnsPackage()
        {
            var dto = new PackageDto
            {
                id = 7,
                name = "BigBox",
                description = "Extreme weight",
                type = "HeavyPackage",
                weight = double.MaxValue
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(double.MaxValue, package.weight);
        }
        [Fact]
        public void CreatePackage_NegativeId_ReturnsPackageWithNegativeId()
        {
            var dto = new PackageDto
            {
                id = -1,
                name = "Invalid",
                description = "Negative id",
                type = "SmallPackage",
                weight = 1.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(-1, package.id);
        }
        [Fact]
        public void CreatePackage_TypeWithSpaces_ReturnsNull()
        {
            var dto = new PackageDto
            {
                id = 8,
                name = "Box",
                description = "Type with spaces",
                type = " HeavyPackage ", 
                weight = 10.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.Null(package);
        }
    }
}
