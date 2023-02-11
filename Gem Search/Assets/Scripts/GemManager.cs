using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    public GemDefinition[] GemDefinitions;

    public GemDefinition RandomDefinition()
    {
        int index = Random.Range(0, GemDefinitions.Length);
        return GemDefinitions[index];
    }
}
