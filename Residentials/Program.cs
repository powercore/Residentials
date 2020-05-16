using System;
using System.Threading;

namespace Residentials
{
 
  class MainClass
  {
    public static void Main(string[] args)
    {
      Residentials building = new Residentials();

      Residentials facility = building.CreateResidentionals("18.12.1984","Elm Street,1428");
      building.ChangeOwner(facility, "Mastah Yoda");
      building.RegisterTenant(facility, "Luke Skywalker");
      building.RegisterTenant(facility, "Obi Wan Lenobi");
      building.DischargeTenant(facility, "Luke Skywalker");
      Thread.Sleep(2000);
      building.DischargeTenant(facility, "Freddy Krueger");

      Console.WriteLine(facility.GetResidentialsInformation("Elm Street,1428"));
      Console.WriteLine(facility.GetResidentialsInformation("Elm Street,1428",DateTime.Now.Subtract(new TimeSpan(0, 0, 2))));

    }
  }
}

