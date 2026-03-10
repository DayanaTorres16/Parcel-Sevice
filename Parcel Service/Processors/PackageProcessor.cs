using System.Text.Json;
using Parcel_Service.Factory;
using Parcel_Service.Packages;

namespace Parcel_Service.Processors
{
    public class PackageProcessor
    {
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
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }   
}