using System.Text.Json;
using Parcel_Service.Interfaces;
using Parcel_Service.Packages;
using Parcel_Service.Factory;

namespace Parcel_Service.Thread
{
    public class PackageProcessor
    {
        private readonly IFileWriterService _writer;

        public PackageProcessor(IFileWriterService writer)
        {
            _writer = writer;
        }

        public async Task<List<Package>> ProcessPackagesAsync(string inputPath, string outputPath)
        {
            string jsonString = await File.ReadAllTextAsync(inputPath);

            try
            {
                List<PackageDto>? dtos = JsonSerializer.Deserialize<List<PackageDto>>(jsonString);

                var results = new List<Package>();

                if (dtos != null)
                {
                    Parallel.ForEach(dtos, dto =>
                    {
                        var package = PackageFactory.CreatePackage(dto);
                        if (package != null)
                        {
                            lock (results)
                            {
                                results.Add(package);
                            }
                        }
                    });
                }

                return [];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }   
}