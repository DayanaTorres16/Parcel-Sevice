using System;
using System.Collections.Generic;

namespace Parcel_Service.Packages;

public abstract class Package
{
    public int id { get; set; } 
    public string name { get; set; } 
    public string description { get; set; } 
    public double weight { get; set; }
    public abstract string type { get; }
    
    public virtual string FormatForOutput()
    {
        return $"{id} | {name} | {description} | {type} | {weight}";
    }
}