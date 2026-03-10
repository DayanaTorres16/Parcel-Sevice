using System;
using System.Collections.Generic;
using Parcel_Service.Interfaces;
using Parcel_Service.Enum;
using Parcel_Service.Formatter;

namespace Parcel_Service.Packages;

public class Package
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; } 
    public double Weight { get; set; }
    public PackageType type { get; set; }

    public virtual string FormatForOutput()
    {
        return PackageFormatter.Format(this);
    }
}