using System;
using System.Collections.Generic;

namespace Residentials
{
  public struct ResidentialsRecord
  {
    public string recordValue;
    public DateTime recordDate;
  }

  public interface IResidentials<T>
    {
      T CreateResidentionals(string buildingDate);
      T ChangeOwner(T obj, string newOwner);
    }

  public class Residentials : IResidentials<Residentials>
  {
      public string BuildingDate { get; set; }
      public string Owner { get; set; }
      public string Address { get; set; }
      public List<ResidentialsRecord> changes = new List<ResidentialsRecord>();
      public List<ResidentialsRecord> registered = new List<ResidentialsRecord>();

      public Residentials CreateResidentionals(string buildingDate)
      {
        Residentials residentials = new Residentials
        {
          BuildingDate = buildingDate
        };
        return residentials;
      }

      public Residentials ChangeOwner(Residentials residentials, string newOwner)
      {
        residentials.Owner = newOwner;
        ResidentialsRecord rr = new ResidentialsRecord { recordValue = $"New owner is {newOwner}", recordDate = DateTime.Now };
        residentials.changes.Add(rr);

        return residentials;
      }

  }
}