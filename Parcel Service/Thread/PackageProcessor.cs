using System.Text.Json;
using Parcel_Service.Packages;
using Parcel_Service.Factory;

namespace Parcel_Service.Thread;

public class PackageProcessor
{
    public async Task<List<Package>> ProcessPackagesAsync(string jsonPath)
    {
        if (!File.Exists(jsonPath))
            throw new FileNotFoundException($"No se encontró el archivo en la ruta: {jsonPath}");
        
        string json = await File.ReadAllTextAsync(jsonPath);
        
        var options = new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        };
        
        var packagesDto = JsonSerializer.Deserialize<List<PackageDto>>(json, options);

        if (packagesDto == null) return new List<Package>();
        
        var tasks = packagesDto.Select(pkg => Task.Run(() => PackageFactory.CreatePackage(pkg)));
        
        var results = await Task.WhenAll(tasks);
        
        return results.Where(p => p != null).Cast<Package>().ToList();
    }
}