using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSurface : MonoBehaviour
{
    private MeshFilter _mf;

    // Start is called before the first frame update
    void Start()
    {
        _mf = GetComponent<MeshFilter>();
        List<Vector3> newVertices = new List<Vector3>();

        foreach(var vert in _mf.mesh.vertices)
        {
            newVertices.Add(new Vector3(vert.x,
                                        vert.y,
                                        Mathf.PerlinNoise(vert.x, vert.y)));
        }

        _mf.mesh.SetVertices(newVertices);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
