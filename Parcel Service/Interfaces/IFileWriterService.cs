namespace Parcel_Service.Interfaces;

public interface IFileWriterService
{
    void WritePackagesToFile(string filePath, List<IFormattablePackage> packages);
}