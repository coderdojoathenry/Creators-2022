using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
  public int GameLengthSeconds = 300;
  public TMP_Text TimeText;
  public GameObject[] GameObjectsToDisable;

  public GameObject GameOverDialog;

  private float _startTime;
  private bool _haveEnded = false;

  // Start is called before the first frame update
  void Start()
  {
    _startTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    int currentTime = GameLengthSeconds - (int)(Time.time - _startTime);
    UpdateTimeOnScreen(currentTime);

    if (currentTime <= 0 && _haveEnded == false)
      EndGame();
  }

  private void UpdateTimeOnScreen(int currentTime)
  {
    int seconds;
    int minutes;

    if (currentTime <= 0)
    {
      seconds = 0;
      minutes = 0;
    }
    else
    {
      seconds = currentTime % 60;
      minutes = (currentTime - seconds) / 60;
    }

    TimeText.text = "Time: " +
                    minutes.ToString() + ":" +
                    seconds.ToString("00");
  }

  private void EndGame()
  {
    // Ending code here
    _haveEnded = true;

    // Disable the objects
    foreach (var obj in GameObjectsToDisable)
    {
      obj.SetActive(false);
    }

    // Show Game Over
    GameOverDialog.SetActive(true);
  }
}