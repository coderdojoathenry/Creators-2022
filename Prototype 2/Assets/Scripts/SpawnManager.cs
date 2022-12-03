using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float spawnDelay = 2;
    private float spawnIntervalMin = 0.5f;
    private float spawnIntervalMax = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
        Invoke("SpawnRandomAnimal", spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
                                       0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex],
                    spawnPos,
                    animalPrefabs[animalIndex].transform.rotation);

        Invoke("SpawnRandomAnimal",
               Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

}
