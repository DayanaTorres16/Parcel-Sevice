using Parcel_Service.Packages;
using Parcel_Service.Interfaces;
using Parcel_Service.Processors;

namespace Parcel_Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string inputPath = Path.Combine(AppContext.BaseDirectory, "packages.json");
            string outputPath = Path.Combine(AppContext.BaseDirectory, "packages_output.txt");

            IFileWriterService writer = new FileWriterService();
            var processor = new PackageProcessor();
            
            var packages = await processor.ProcessPackagesAsync(inputPath, outputPath);
            
            writer.WritePackagesToFile(outputPath, packages);

            Console.WriteLine("Packages processed and written in packages_output.txt");
        }
    }
}