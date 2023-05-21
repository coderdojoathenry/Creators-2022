using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoAddHighScore : MonoBehaviour
{
  public GemInventory GemInventory;
  public TMP_InputField InputField;
  public HighScore HighScore;

  public void AddScore()
  {
    HighScore.AddScore(InputField.text, GemInventory.Score);
  }
}
