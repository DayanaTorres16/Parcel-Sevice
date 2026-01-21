using Parcel_Service.Singleton;
using Parcel_Service.Packages;
using Parcel_Service.Thread;

class Program
{
    static async Task Main(string[] args)
    {
        string inputPath = Path.Combine(AppContext.BaseDirectory, "packages.json");
        string outputPath = "packages_output.txt";
        
        PackageProcessor processor = new PackageProcessor();
        List<Package> supportedPackages = await processor.ProcessPackagesAsync(inputPath);
        
        FileWriterService.Instance.WritePackagesToFile(outputPath, supportedPackages);

        Console.WriteLine("Paquetes procesados y escritos en packages_output.txt");
    }
}