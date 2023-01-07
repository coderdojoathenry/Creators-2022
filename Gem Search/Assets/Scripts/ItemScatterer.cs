using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScatterer : MonoBehaviour
{
    public Vector3 size;
    public float spacing = 3.0f;
    public GameObject item;
    public float probability = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Distribute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Distribute()
    {
        Vector3 start = new Vector3(transform.position.x - size.x / 2.0f,
                                    transform.position.y + size.y / 2.0f,
                                    transform.position.z - size.z / 2.0f);

        for (float xOffset = 0.0f; xOffset < size.x; xOffset += spacing)
        {
            for (float zOffset = 0.0f; zOffset < size.z; zOffset += spacing)
            {
                Vector3 thisPos = start + new Vector3(xOffset, 0.0f, zOffset);

                // Check pobability
                if (probability < Random.value)
                {
                    // Check for ground
                    RaycastHit hit = new RaycastHit();
                    //if (Physics.Raycast())
                    //{

                    //}
                }
            }
        }
    }
}
