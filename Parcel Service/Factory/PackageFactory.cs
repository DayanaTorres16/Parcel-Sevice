using Parcel_Service.Enum;
using Parcel_Service.Packages;
namespace Parcel_Service.Factory;

public static class PackageFactory
{
    public static Package? CreatePackage(PackageDto dto)
    {
        switch (dto.type)
        {
            case "Documents":
                return new Package()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Weight = dto.Weight,
                    type = PackageType.Documents
                };
            case "HeavyPackage":
                return new Package()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Weight = dto.Weight,
                    type = PackageType.HeavyPackage
                };
            case "SmallPackage":
                return new Package()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Weight = dto.Weight,
                    type = PackageType.SmallPackage
                };
            default:
                return null;
        }
    }
}
