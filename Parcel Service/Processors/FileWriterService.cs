using Parcel_Service.Interfaces;
using Parcel_Service.Packages;

namespace Parcel_Service.Processors
{
    public sealed class FileWriterService : IFileWriterService
    {
        
        public void WritePackagesToFile(string filePath, List<Package> packages)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id | Name | Description | Type | Weight");
                writer.WriteLine(new string('-', 100));
                
                Parallel.ForEach(packages, package =>
                {
                    lock (writer) 
                    {
                        writer.WriteLine(package.FormatForOutput());
                    }
                });
            }
        }

    }
}