using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnInterval : MonoBehaviour
{
    public GameObject prefab;
    public float delaySeconds = 1.0f;

    private float sinceLastSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sinceLastSpawn += Time.deltaTime;

        if (sinceLastSpawn > delaySeconds)
        {
            // create a prefab
            Instantiate(prefab, transform.position, transform.rotation);

            // set sinceLastSpawn to zero
            sinceLastSpawn = 0.0f;
        }

    }
}
