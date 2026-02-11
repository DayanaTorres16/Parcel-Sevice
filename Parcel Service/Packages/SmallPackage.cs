using Parcel_Service.Enum;
namespace Parcel_Service.Packages;

public class SmallPackage:Package
{
    public override PackageType type => PackageType.SmallPackage;
}