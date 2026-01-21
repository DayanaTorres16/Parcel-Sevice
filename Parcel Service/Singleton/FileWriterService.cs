using Parcel_Service.Packages;
namespace Parcel_Service.Singleton;

public sealed class FileWriterService
{
    private static readonly FileWriterService instance = new FileWriterService();
    public static FileWriterService Instance => instance;
    private FileWriterService() { }
    
    public void WritePackagesToFile(string filePath, List<Package> packages)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Id | Name | Description | Type | Weight");
            writer.WriteLine(new string('-', 80));

            foreach (var package in packages)
            {
                writer.WriteLine(package.FormatForOutput());
            }
        }
    }
}
