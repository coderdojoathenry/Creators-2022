using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GemInventoryAreaStorage : GemInventoryAreaBase
{
  public GemManager GemManager;
  public int Score = 0;

  public GemInventoryAreaStorage() : base(GemInventoryAreaType.Storage)
  {

  }

  public override IEnumerable<GemDefinition> GetSlotEnumerator()
  {
    return GemManager.GemDefinitions.AsEnumerable<GemDefinition>();
  }

  public override bool Add(GemDefinition gd, bool force = false)
  {
    Score += gd.Value;

    return base.Add(gd, force);
  }

  public override bool Remove(GemDefinition gd)
  {
    Score -= gd.Value;
    return base.Remove(gd);
  }
}
