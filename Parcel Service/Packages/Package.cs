using System;
using System.Collections.Generic;
using Parcel_Service.DesignFormat;
using Parcel_Service.Interfaces;
using Parcel_Service.Enum;

namespace Parcel_Service.Packages;

public abstract class Package: IPackage,  IFormattablePackage
{
    public int id { get; set; } 
    public string name { get; set; } 
    public string description { get; set; } 
    public double weight { get; set; }
    public abstract PackageType type { get;  }

    public virtual string FormatForOutput()
    {
        return PackageFormatter.Format(this);
    }
}