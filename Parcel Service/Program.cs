using Parcel_Service.Packages;
using Parcel_Service.Singleton;
using Parcel_Service.Interfaces;
using Parcel_Service.Thread;

class Program
{
    static async Task Main()
    {
        string inputPath = Path.Combine(AppContext.BaseDirectory, "packages.json");
        string outputPath = Path.Combine(AppContext.BaseDirectory, "packages_output.txt");

        IFileWriterService writer = new FileWriterService();
        var processor = new PackageProcessor();

        await processor.ProcessPackagesAsync(inputPath, outputPath);

        Console.WriteLine("Packages processed and written in packages_output.txt");
    }
}