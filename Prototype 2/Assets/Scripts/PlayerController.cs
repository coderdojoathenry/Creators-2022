using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public GameObject projectilePrefab;
    public float projectileDelay = 0.3f;

    private float timeSinceLastProjectile = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput *
                    Time.deltaTime * speed);

        // Check left side
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,
                                             transform.position.y,
                                             transform.position.z);
                
        }

        //Check right side
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,
                                             transform.position.y,
                                             transform.position.z);

        }

        // Is the spacebar pressed and is it long enough since
        // we last fired a projectile?
        if (Input.GetKeyDown(KeyCode.Space) &&
            timeSinceLastProjectile > projectileDelay)
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab,
                        transform.position,
                        transform.rotation);

            timeSinceLastProjectile = 0;
        }
        else
        {
            timeSinceLastProjectile += Time.deltaTime;
        }
    }
}
