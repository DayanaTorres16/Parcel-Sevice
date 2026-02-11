using Parcel_Service.Enum;
namespace Parcel_Service.Packages;

public class DocumentPackage:Package
{
    public override PackageType type => PackageType.Documents;
}