using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInventoryAreaSensor : GemInventoryAreaBase
{
  public GemInventoryAreaSensor() : base(GemInventoryAreaType.Sensor, 4)
  {

  }

  public override bool CanAdd(GemDefinition gd)
  {
    GemDefinition sameLevel = _contents.Find(p => p.Level == gd.Level);
    return sameLevel == null;
  }
}
