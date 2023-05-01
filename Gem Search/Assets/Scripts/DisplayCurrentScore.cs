using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrentScore : MonoBehaviour
{
  public GemInventory Inventory;
  public TMP_Text Score;

  private void Update()
  {
    if (Inventory != null)
      Score.text = "Score: " + Inventory.Score.ToString();
  }
}
