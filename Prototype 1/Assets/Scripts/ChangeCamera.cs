using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public KeyCode keyCode;
    private Camera[] cameras;
    private int currentCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameras = GetComponentsInChildren<Camera>();
        SelectCamera(currentCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            currentCamera++;
            SelectCamera(currentCamera);
        }
    }

    void SelectCamera(int which)
    {
        which = which % cameras.Length;

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == which);
        }
    }
}
