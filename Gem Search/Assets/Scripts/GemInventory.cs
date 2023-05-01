using StarterAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GemInventory : MonoBehaviour
{
  public GemManager GemManager;
  public GameObject InventoryCanvas;
  public StarterAssetsInputs StarterAssetInputs;

  private List<GemInventoryAreaBase> _areas;
  private bool _inventoryOpen = false;
  private CursorLockMode _prevCursorLockState = CursorLockMode.None;
  private bool _prevCursorInputForLook = true;

  public int Score
  {
    get
    {
      GemInventoryAreaStorage storage = _areas.Find(p => p.Type == GemInventoryAreaBase.GemInventoryAreaType.Storage) as GemInventoryAreaStorage;
      return storage == null ? 0 : storage.Score;
    }
  }

  private void Start()
  {
    _areas = GetComponents<GemInventoryAreaBase>().ToList();

    AddRandomSensorGem();
  }

  private void AddRandomSensorGem()
  {
    GemDefinition gd = GemManager.RandomDefinition();

    while (gd.Level != 0)
      gd = GemManager.RandomDefinition();

    GemInventoryAreaBase sensor = _areas.Find(p => p.Type == GemInventoryAreaBase.GemInventoryAreaType.Sensor);
    sensor.Add(gd);
  }

  private void Update()
  {
    GemInventoryAreaBase craftingIn = _areas.Find(p => p.Type == GemInventoryAreaBase.GemInventoryAreaType.CraftingInput);
    GemInventoryAreaBase craftingOut = _areas.Find(p => p.Type == GemInventoryAreaBase.GemInventoryAreaType.CraftingOutput);
    GemDefinition gd = GemManager.CraftingInputsMatchRecipe(craftingIn.GetSlotEnumerator());

    if (gd != null && craftingOut.Add(gd, true))
    {
      craftingIn.DeleteAll();
    }
  }

  public void ToggleInventory()
  {
    _inventoryOpen = !_inventoryOpen;
    bool playerHasCursor = !_inventoryOpen;

    InventoryCanvas.SetActive(_inventoryOpen);

    if (_inventoryOpen)
    {
      _prevCursorLockState = Cursor.lockState;
      Cursor.lockState = CursorLockMode.None;

      _prevCursorInputForLook = StarterAssetInputs.cursorInputForLook;
      StarterAssetInputs.cursorInputForLook = false;
    }
    else
    {
      Cursor.lockState = _prevCursorLockState;
      StarterAssetInputs.cursorInputForLook = _prevCursorInputForLook;
    }
  }

  public void Add(GemDefinition gd)
  {
    GemInventoryAreaStorage storage = _areas.Find(p => p.Type == GemInventoryAreaBase.GemInventoryAreaType.Storage) as GemInventoryAreaStorage;

    if (storage != null)
      storage.Add(gd, true);
  }

  public void DragBetween(GemInventoryAreaBase.GemInventoryAreaType fromType,
                          GemInventoryAreaBase.GemInventoryAreaType toType,
                          GemDefinition gd)
  {
    GemInventoryAreaBase fromArea = _areas.Find(p => p.Type == fromType);
    GemInventoryAreaBase toArea = _areas.Find(p => p.Type == toType);

    if (fromArea == null || toArea == null)
      return;

    if (toArea.Add(gd))
      fromArea.Remove(gd);
  }
}