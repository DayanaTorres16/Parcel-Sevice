using System;
using System.Collections.Generic;
using Parcel_Service.DesignFormat;
using Parcel_Service.Interfaces;
using Parcel_Service.Enum;

namespace Parcel_Service.Packages;

public class Package
{
    public int id { get; set; } 
    public string name { get; set; } 
    public string description { get; set; } 
    public double weight { get; set; }
    public PackageType type { get; set; }

    public virtual string FormatForOutput()
    {
        return PackageFormatter.Format(this);
    }
}