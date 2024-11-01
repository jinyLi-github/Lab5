using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipPlayer : MonoBehaviour
{
    public Vector3 shipMovement;
    public Rigidbody rb;
    public float speed = 10f;
    public float rotationTilee=20f;

    public GameObject boltPrefab;
    public Transform shootingPoint;

    public float lastFireTime = 0f;
    public float fireCooldown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //boltPrefab.SetActive(false);

    }
    void Update()
    {
        if (InputManager.instance.fireAction.triggered && Time.time >= lastFireTime + fireCooldown)
        {
            Debug.Log("Fire action triggered!");
            // boltPrefab.SetActive(true);
            Instantiate(boltPrefab, shootingPoint.position, shootingPoint.rotation);
            lastFireTime = Time.time;
        }
    }
    public void FixedUpdate()
    {
        //get input movement from InputManager
        Vector2 moveInput = InputManager.instance.moveAction.ReadValue<Vector2>();
        
        //Apply movement
        shipMovement = new Vector3 (moveInput.x, 0, moveInput.y) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + shipMovement);

        //restrict player position by bonds;
        float clampedX = Mathf.Clamp(rb.position.x, -4f, 4f);
        float clampedZ = Mathf.Clamp(rb.position.z, -1f, 11f);

        rb.position = new Vector3(clampedX, rb.position.y, clampedZ);

        //rotation
        float rotationValue = -moveInput.x * rotationTilee;
        rb.rotation = Quaternion.Euler(0, 0, rotationValue);
    }

}
