using Parcel_Service.Packages;

namespace Parcel_Service.Interfaces;

public interface IFileWriterService
{
    void WritePackagesToFile(string filePath, List<Package> packages);
}