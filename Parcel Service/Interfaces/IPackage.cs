namespace Parcel_Service.Interfaces;

public interface IPackage
{
    int id { get; }
    string name { get; }
    string description { get; }
    double weight { get; }
    string type { get; }
}
