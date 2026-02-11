using Parcel_Service.Interfaces;
using Parcel_Service.Packages;
using Parcel_Service.Interfaces; 
namespace Parcel_Service.Singleton;

public sealed class FileWriterService : IFileWriterService
{
    private static readonly FileWriterService instance = new FileWriterService();
    public static IFileWriterService Instance => instance;
    private FileWriterService() { }

    public void WritePackagesToFile(string filePath, List<IFormattablePackage> packages)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Id | Name | Description | Type | Weight");
            writer.WriteLine(new string('-', 100));

            foreach (var package in packages)
            {
                writer.WriteLine(package.FormatForOutput());
            }
        }
    }
}
