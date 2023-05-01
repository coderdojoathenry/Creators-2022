using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GemInventoryAreaBase : MonoBehaviour
{
  public enum GemInventoryAreaType { Storage, CraftingInput, CraftingOutput, Sensor }

  public InventorySlot[] InventorySlots;

  public GemInventoryAreaType Type
  {
    get;
    private set;
  }

  internal List<GemDefinition> _contents;
  internal int? _maxContentCount;
  private GemInventory _inventory;

  public GemInventoryAreaBase(GemInventoryAreaType type,
                              int? maxContentCount = null)
  {
    Type = type;
    _maxContentCount = maxContentCount;
  }

  // Start is called before the first frame update
  void Start()
  {
    _inventory = GetComponent<GemInventory>();
    _contents = new List<GemDefinition>();
    RegisterSlots();
  }

  // Update is called once per frame
  void Update()
  {
    IEnumerable<GemDefinition> slotEnumerator = GetSlotEnumerator();

    for (int i = 0; i < InventorySlots.Count(); i++)
    {
      GemDefinition gd = null;

      if (i < slotEnumerator.Count())
      {
        gd = slotEnumerator.ElementAt(i);
      }

      // Tell the slot what we have
      InventorySlots[i].SetDetails(gd, Count(gd));
    }
  }

  public virtual bool Add(GemDefinition gd, bool force = false)
  {
    bool canAdd = CanAdd(gd);
    if (canAdd || force)
    {
      _contents.Add(gd);
      return true;
    }

    return false;
  }

  public virtual bool CanAdd(GemDefinition gd)
  {
    if (_maxContentCount == null)
      return true;

    return _contents.Count < _maxContentCount.Value;
  }

  public virtual bool Remove(GemDefinition gd)
  {
    return _contents.Remove(gd);
  }

  public void DeleteAll()
  {
    _contents.Clear();
  }

  public int Count(GemDefinition gd)
  {
    return _contents.FindAll(p => p == gd).Count;
  }

  public virtual IEnumerable<GemDefinition> GetSlotEnumerator()
  {
    return _contents.AsEnumerable<GemDefinition>();
  }

  private void RegisterSlots()
  {
    foreach (var slot in InventorySlots)
    {
      slot.RegisterSlot(Type, _inventory);
    }
  }
}
