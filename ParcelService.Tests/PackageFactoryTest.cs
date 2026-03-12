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
                Id = 1,
                Name = "Doc1",
                Description = "Important papers",
                type = "Documents",
                Weight = 0.5
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.Documents, package.type);
            Assert.Equal(dto.Id, package.Id);
            Assert.Equal(dto.Name, package.Name);
            Assert.Equal(dto.Description, package.Description);
            Assert.Equal(dto.Weight, package.Weight);
        }
        [Fact]
        public void CreatePackage_HeavyPackage_ReturnsHeavyPackage()
        {
            var dto = new PackageDto
            {
                Id = 2,
                Name = "Box",
                Description = "Heavy box",
                type = "HeavyPackage",
                Weight = 100.0
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
                Id = 3,
                Name = "Gift",
                Description = "Small gift",
                type = "SmallPackage",
                Weight = 1.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.SmallPackage, package.type);
        }
        
        [Fact]
        public void CreatePackage_ExtremeWeight_ReturnsPackage()
        {
            var dto = new PackageDto
            {
                Id = 7,
                Name = "BigBox",
                Description = "Extreme weight",
                type = "HeavyPackage",
                Weight = double.MaxValue
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(double.MaxValue, package.Weight);
        }
        
        [Fact]
        public void CreatePackage_NegativeId_ReturnsPackageWithNegativeId()
        {
            var dto = new PackageDto
            {
                Id = -1,
                Name = "Invalid",
                Description = "Negative id",
                type = "SmallPackage",
                Weight = 1.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(-1, package.Id);
        }
        
        [Fact]
        public void CreatePackage_TypeWithSpaces_ReturnsValidPackage()
        {
            var dto = new PackageDto
            {
                Id = 8,
                Name = "Box",
                Description = "Type with spaces",
                type = " HeavyPackage ", 
                Weight = 10.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.NotNull(package);
            Assert.Equal(PackageType.HeavyPackage, package.type);
        }
        
        [Fact]
        public void CreatePackage_InvalidType_ReturnsNull()
        {
            var dto = new PackageDto
            {
                Id = 4,
                Name = "Unknown",
                Description = "Invalid type",
                type = "Pizza", 
                Weight = 2.0
            };

            var package = PackageFactory.CreatePackage(dto);

            Assert.Null(package);
        }
    }
}
