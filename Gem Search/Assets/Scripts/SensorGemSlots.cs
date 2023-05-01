using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorGemSlots : MonoBehaviour
{
  public GemInventoryAreaSensor InventorySensorArea;
  public Transform[] SpawnLocations;
  public GemDefinition[] CurrentGemDefs = new GemDefinition[] { null, null, null, null };

  // Update is called once per frame
  void Update()
  {
    if (InventorySensorArea == null)
      return;

    if (SpawnLocations == null || SpawnLocations.Length < 4)
      return;

 
    for (int level = 0; level < 4; level++)
    {
      GemDefinition gd = InventorySensorArea._contents.Find(p => p.Level == level);
    
      if (CurrentGemDefs[level] != gd)
      {
        // Destroy the existing prefab, if there is one
        if (SpawnLocations[level].childCount > 0)
        {
          Destroy(SpawnLocations[level].GetChild(0).gameObject);
        }

        if (gd != null)
          Instantiate(gd.Prefab, SpawnLocations[level]);

        CurrentGemDefs[level] = gd;
      }
    }
  }
}
