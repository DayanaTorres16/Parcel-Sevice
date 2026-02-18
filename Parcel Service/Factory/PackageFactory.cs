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
                    id = dto.id,
                    name = dto.name,
                    description = dto.description,
                    weight = dto.weight,
                    type = PackageType.Documents
                };
            case "HeavyPackage":
                return new Package()
                {
                    id = dto.id,
                    name = dto.name,
                    description = dto.description,
                    weight = dto.weight,
                    type = PackageType.HeavyPackage
                };
            case "SmallPackage":
                return new Package()
                {
                    id = dto.id,
                    name = dto.name,
                    description = dto.description,
                    weight = dto.weight,
                    type = PackageType.SmallPackage
                };
            default:
                return null;
        }
    }
}
