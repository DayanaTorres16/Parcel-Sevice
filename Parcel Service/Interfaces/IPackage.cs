using Parcel_Service.Enum;

namespace Parcel_Service.Interfaces;

public interface IPackage
{
    int id { get; }
    string name { get; }
    string description { get; }
    double weight { get; }
    PackageType type { get; }
}
