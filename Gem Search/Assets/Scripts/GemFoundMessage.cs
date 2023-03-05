using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemFoundMessage : MonoBehaviour
{
    public TMP_Text Text;
    public Transform GemHolder;

    public void SetGemDefinition(GemDefinition gd)
    {
        string message = string.Format("You found a {0} spirit gem!",
                                       gd.name);
        Text.text = message;

        Instantiate(gd.Prefab,
                    Vector3.zero,
                    gd.Prefab.transform.rotation,
                    GemHolder);
    }
}
