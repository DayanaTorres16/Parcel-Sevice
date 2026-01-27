using Parcel_Service.Packages;
namespace Parcel_Service.Factory;

public static class PackageFactory
{
    public static Package? CreatePackage(PackageDto dto)
    {
        switch (dto.type)
        {
            case "Documents":
                return new DocumentPackage
                {
                    id = dto.id,
                    name = dto.name,
                    description = dto.description,
                    weight = dto.weight
                };
            case "HeavyPackage":
                return new HeavyPackage
                {
                    id = dto.id,
                    name = dto.name,
                    description = dto.description,
                    weight = dto.weight
                };
            case "SmallPackage":
                return new SmallPackage
                {
                    id = dto.id,
                    name = dto.name,
                    description = dto.description,
                    weight = dto.weight
                };
            default:
                return null;
        }
    }
}
