using System;
using System.Collections.Generic;
using Parcel_Service.Enum;

namespace Parcel_Service.Packages;

public class HeavyPackage:Package
{
    public override PackageType type => PackageType.HeavyPackage;
}