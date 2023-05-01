using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInventoryAreaCraftingOut : GemInventoryAreaBase
{
  public GemInventoryAreaCraftingOut() : base(GemInventoryAreaType.CraftingOutput, 1)
  {

  }

  public override bool CanAdd(GemDefinition gd)
  {
    return false;
  }
}
