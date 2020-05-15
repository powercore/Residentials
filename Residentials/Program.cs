using System;

namespace Residentials
{
 
  class MainClass
  {
    public static void Main(string[] args)
    {
      Residentials building = new Residentials();

      Residentials facility = building.CreateResidentionals("18.12.1971");
      building.ChangeOwner(facility, "Mastah Yoda");

      Console.WriteLine(facility.Owner);
      foreach (ResidentialsRecord rec in facility.changes)
      Console.WriteLine($"{rec.recordDate}: {rec.recordValue}");
    }
  }
}

