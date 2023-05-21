using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheat : MonoBehaviour
{
  public GemInventory GemInventory;
  public GemManager GemManager;
  public int NumberOfGems;

  public void InventoryCheatClicked()
  {
    Invoke("AddRandomGem", 1.0f);
  }
  private void AddRandomGem()
  {
    GemInventory.Add(GemManager.RandomDefinition());
    NumberOfGems--;

    if (NumberOfGems > 0)
      Invoke("AddRandomGem", 1.0f);
  }

}
