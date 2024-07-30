using Unity.Burst;

public class Masses
{
    // https://nssdc.gsfc.nasa.gov/planetary/factsheet/sunfact.html
    public const double sun = 1.988400e30;
    public const double earth = 5.9722e24;
}

public class Distances
{
    // https://cneos.jpl.nasa.gov/glossary/au.html
    public const long earth = 149597870700;
}

public class Radii
{
    public const long sun = 695700*1000;
    public const long jupiter = 69911*1000;
    public const long earth = 6371*1000;
    public const long ganymede = 2634*1000;
}

public class Physical_Constants
{
    public const double g = 6.67430e-11;
}