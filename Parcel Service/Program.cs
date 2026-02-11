using System.Collections.Generic;
using Parcel_Service.Packages;
using Parcel_Service.Singleton;
using Parcel_Service.Interfaces;

class Program
{
    static async Task Main()
    {
        string inputPath = Path.Combine(AppContext.BaseDirectory, "packages.json");
        
        string outputPath = Path.Combine(AppContext.BaseDirectory, "packages_output.txt");
        
        var processor = new PackageProcessor();
        List<Package> supportedPackages = await processor.ProcessPackagesAsync(inputPath);
        
        IFileWriterService writer = FileWriterService.Instance;
        writer.WritePackagesToFile(outputPath, supportedPackages.Cast<IFormattablePackage>().ToList());

        Console.WriteLine("Packages processed and written in packages_output.txt");
    }
}