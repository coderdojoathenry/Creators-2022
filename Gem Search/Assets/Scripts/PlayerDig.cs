using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    public string GroundLayer = "Ground";
    public GameObject DiggingPrefab;

    public void OnDig()
    {
        Debug.Log("Player hit dig");

        Vector3 rayPos = transform.position +
                         (transform.forward * 2) +
                         (Vector3.up * 2);
        LayerMask lm = LayerMask.GetMask(GroundLayer);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(rayPos, Vector3.down, out hitInfo, 10.0f, lm))
        {
            Instantiate(DiggingPrefab, hitInfo.point,
                        DiggingPrefab.transform.rotation);
        }

    }
}
