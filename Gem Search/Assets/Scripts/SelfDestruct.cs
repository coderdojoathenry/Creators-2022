using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float SelfDestructInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, SelfDestructInSeconds);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
