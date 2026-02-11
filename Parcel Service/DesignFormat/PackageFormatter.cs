using Parcel_Service.Packages;

namespace Parcel_Service.DesignFormat
{
    public static class PackageFormatter
    {
        public static string Format(Package package)
        {
            return package.id.ToString().PadRight(5) + " | " +
                   package.name.PadRight(25) + " | " +
                   package.description.PadRight(30) + " | " +
                   package.type.ToString().PadRight(35) + " | " +
                   package.weight.ToString("F2").PadRight(10);
        }

        public static string Header()
        {
            return "Id".PadRight(5) + " | " +
                   "Name".PadRight(25) + " | " +
                   "Description".PadRight(30) + " | " +
                   "Type".PadRight(35) + " | " +
                   "Weight".PadRight(10);
        }
    }
    

}