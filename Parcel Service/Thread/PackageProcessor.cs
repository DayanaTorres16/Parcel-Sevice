using System.Text.Json;
using System.Text.Json.Serialization;
using Parcel_Service.Packages;
using Parcel_Service.Factory;

public class PackageProcessor
{
    public async Task<List<Package>> ProcessPackagesAsync(string filePath)
    {
        string jsonString = await File.ReadAllTextAsync(filePath);

        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

        List<PackageDto>? dtos = JsonSerializer.Deserialize<List<PackageDto>>(jsonString, options);

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
}