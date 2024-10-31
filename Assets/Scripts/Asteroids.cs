using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Rigidbody rb;

    public float rotationSpeed = 100f;
    float randomX;
    float randomY;
    float randomZ;
    // Minimum y-position to prevent asteroids from moving below the background
    private float minYPosition = -1f;

    public float speed = 10f;
    public Transform player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set initial position slightly above the background level
        if (transform.position.y < minYPosition)
        {
            transform.position = new Vector3(transform.position.x, minYPosition + 0.5f, transform.position.z);
        }

        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(0f, 0.1f);
        randomZ = Random.Range(-1f, 1f);
        Vector3 randomRotation = new Vector3(randomX, randomY, randomZ).normalized;

        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = randomRotation * rotationSpeed;
        // Ensure the asteroid starts with a reasonable upward velocity to avoid falling through the ground
       // rb.velocity = Vector3.up * speed;
    }

    private void FixedUpdate()
    {
        //continuesly rotate the asteroid
        Vector3 randomRotation = new Vector3(randomX, randomY, randomZ).normalized;
        rb.angularVelocity = randomRotation * rotationSpeed;

        //Move the asteroid toward the player
        if(player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }

        // Clamp the y-position to prevent it from moving below the background
        if (transform.position.y < minYPosition)
        {
            transform.position = new Vector3(transform.position.x, minYPosition, transform.position.z);
        }
    }
    // Update is called once per frame
   
  
}
