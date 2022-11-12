using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 50.0f;
    public string HorizontalAxis = "Horizontal";
    public string VerticalAxis = "Vertical";
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player input
        horizontalInput = Input.GetAxis(HorizontalAxis);
        forwardInput = Input.GetAxis(VerticalAxis);

        //  Move our vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime *
                            speed * forwardInput);

        // Rotate our vehicle 
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime *
                         horizontalInput);
    }
}
