using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsReturn : MonoBehaviour
{
  public float DelaySeconds = 105;
  public string SceneName = "[Start Screen]";

  // Start is called before the first frame update
  void Start()
  {
    Invoke("ChangeScene", DelaySeconds);
  }

  private void ChangeScene()
  {
    SceneManager.LoadScene(SceneName);
  }

}
