using System;
using System.Collections.Generic;

namespace Residentials
{

  public static class Helpers
  {
    public static bool Exists(this object obj)
    {
      return (obj != null) ? true : false;
    }
  }

  public struct ResidentialsRecord
  {
    public string recordValue;
    public DateTime recordDate;
  }

  public interface IResidentials<T>
    {
      // Create new residentionals
      T CreateResidentionals(string buildingDate, string adress);

      // Change the owner of facility
      T ChangeOwner(T obj, string newOwner);

      // Register new tenant in facility
      T RegisterTenant(T obj, string tenant);

      // Discharge tenant from facility
      T DischargeTenant(T pbj, string tenant);

      // Get all infos about facility
      string GetResidentialsInformation(string address);

      // Get all infos about facility from some date
      string GetResidentialsInformation(string address, DateTime date);

    }

  public class Residentials : IResidentials<Residentials>
  {
      public string BuildingDate { get; set; }
      public string Owner { get; set; }
      public string Address { get; set; }
      public List<ResidentialsRecord> changes = new List<ResidentialsRecord>();
      public List<string> tenants = new List<string>();

      public Residentials CreateResidentionals(string buildingDate, string address)
      {
        Residentials residentials = new Residentials
        {
          BuildingDate = buildingDate,
          Address = address
        };
        return residentials;
      }

      public Residentials ChangeOwner(Residentials residentials, string newOwner)
      {
        if (residentials.Exists())
        { 
          residentials.Owner = newOwner;
          residentials.changes.Add(new ResidentialsRecord { recordValue = $"New owner is {newOwner}", recordDate = DateTime.Now });
        }
      return residentials;
      }

      public Residentials RegisterTenant(Residentials residentials, string tenant)
      {
       if (residentials.Exists())
       {
          residentials.tenants.Add(tenant);
          residentials.changes.Add(new ResidentialsRecord { recordValue = $"Registered new tenant {tenant}", recordDate = DateTime.Now });
       }
        return residentials;
      }

    public Residentials DischargeTenant(Residentials residentials, string tenant)
    {
      if (residentials.Exists())
      {
        for (int i = 0; i < residentials.tenants.Count; i++)
        {
          if (residentials.tenants[i] == tenant)
          {
            residentials.tenants.RemoveAt(i);
            residentials.changes.Add(new ResidentialsRecord { recordValue = $"Discharged tenant {tenant}", recordDate = DateTime.Now });
            return residentials;
          }
        }
        residentials.changes.Add(new ResidentialsRecord { recordValue = $"Error while trying to discharge {tenant}", recordDate = DateTime.Now });
        return residentials;
      }
      return null;
    }

    public string GetResidentialsInformation(string address)
    {
      if (address == Address)
      { 
      string result = $"Residentials with address: {Address}. Building date: {BuildingDate}\n";
        result += "Tenants:\n";

        foreach (string tenant in tenants)
          result += tenant + "\n";

        result += "History:\n";

        foreach (ResidentialsRecord rr in changes)
          result += $"{rr.recordDate}: {rr.recordValue}\n";

        return result;
      }
      return "Error! Address not match!";
    }

    public string GetResidentialsInformation(string address, DateTime date)
    {
      if (address == Address)
      {
        string result = $"Residentials with address:{Address}. Building date: {BuildingDate}\n";
        result += "Tenants:\n";

        foreach (string tenant in tenants)
          result += tenant + "\n";

        result += $"History after {date}:\n";

        foreach (ResidentialsRecord rr in changes)
        { 
          if (rr.recordDate> date)
            result += $"{rr.recordDate}: {rr.recordValue}\n";
        }
        return result;
      }
      return "Error! Address not match!";
    }
  }
}