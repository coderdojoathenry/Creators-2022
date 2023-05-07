using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDig : MonoBehaviour
{
  public string GroundLayer = "Ground";
  public GameObject DiggingPrefab;
  public ItemScatterer ItemScatterer;
  public float MaxDistToItem = 0.35f;
  public GameObject GemFoundPrefab;
  public Transform GemFoundLocation;
  public GemInventory Inventory;

  public void OnDig()
  {
    Debug.Log("Player hit dig");

    Vector3 rayPos = transform.position +
                     (transform.forward * 2) +
                     (Vector3.up * 2);
    LayerMask lm = LayerMask.GetMask(GroundLayer);
    RaycastHit hitInfo = new RaycastHit();
    if (Physics.Raycast(rayPos, Vector3.down, out hitInfo, 10.0f, lm))
    {
      Instantiate(DiggingPrefab, hitInfo.point,
                  DiggingPrefab.transform.rotation);
      Invoke("DigResult", 3);
    }
  }

  private void DigResult()
  {
    //float distToNearest = (ItemScatterer.nearestItem.transform.position -
    //                       transform.position).magnitude;

    Vector3 nearestPos = ItemScatterer.nearestItem.transform.position;
    Vector3 nearestHoriz = new Vector3(nearestPos.x, 0, nearestPos.z);
    Vector3 thisHoriz = new Vector3(transform.position.x, 0, transform.position.z);
    float distToNearest = (nearestHoriz - thisHoriz).magnitude;

    if (distToNearest > MaxDistToItem)
      return;

    // Capture the gem definition
    RandomGem rg = ItemScatterer.nearestItem.GetComponent<RandomGem>();
    GemDefinition gd = rg.GemDefinition;

    // Remove the item from ItemScatterer
    Destroy(ItemScatterer.nearestItem);
    ItemScatterer.nearestItem = null;

    // Add to our inventory
    Inventory.Add(gd);

    // Spawn the Gem Found Prefab to let the player know what they found
    GameObject gfb = Instantiate(GemFoundPrefab, GemFoundLocation);
    GemFoundMessage gfm = gfb.GetComponent<GemFoundMessage>();
    GameObject gem = Instantiate(gd.Prefab, gfm.GemHolder);
    gfm.SetGemDefinition(gd);
  }
}
