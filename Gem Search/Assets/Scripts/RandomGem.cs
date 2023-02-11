using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGem : MonoBehaviour
{
    public GemDefinition GemDefinition;

    // Start is called before the first frame update
    void Start()
    {
        GemManager gm = FindObjectOfType<GemManager>();

        if (gm != null)
        {
            GemDefinition = gm.RandomDefinition();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}