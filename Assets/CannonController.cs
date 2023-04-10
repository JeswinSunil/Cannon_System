using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    //public float rotationSpeed = 5f;
    //public float launchForce = 1000f;
    //public GameObject projectilePrefab;
    //public Transform launchPoint;

    //public float moveSpeed = 5f; // The speed at which the cannon moves up and down
    //public float maxHeight = 10f; // The maximum height the cannon can be raised to
    //public float minHeight = 0f; // The minimum height the cannon can be lowered to
    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos.z = 10f;
    //    Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
    //    target.y = transform.position.y;
    //    transform.LookAt(target);
    //    fire();

    //    // Move the cannon up or down based on input
    //    float inputY = Input.GetAxis("Vertical");
    //    transform.position += new Vector3(0f, inputY * moveSpeed * Time.deltaTime, 0f);

    //    // Clamp the cannon's position to the valid range
    //    Vector3 pos = transform.position;
    //    pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
    //    transform.position = pos;
    //}

    //void fire()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
    //        Rigidbody rb = projectile.GetComponent<Rigidbody>();
    //        rb.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
    //    }
    //}

    public Transform cannonBarrel;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float maxProjectileArc = 45f;
    public float minProjectileArc = 0f;
    public float cannonRotationSpeed = 5f;
    public float cannonVerticalSpeed = 5f;

    private float currentArc = 0f;

    void Update()
    {
        // Rotate the cannon barrel left or right based on mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * cannonRotationSpeed);

        // Adjust the projectile arc up or down based on up/down arrow keys
        float verticalInput = Input.GetAxis("Vertical");
        currentArc = Mathf.Clamp(currentArc + verticalInput * cannonVerticalSpeed, minProjectileArc, maxProjectileArc);
        cannonBarrel.localRotation = Quaternion.Euler(currentArc, 0f, 0f);

        // Fire a projectile when left mouse button is clicked
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(projectilePrefab, cannonBarrel.position, cannonBarrel.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.velocity = cannonBarrel.forward * projectileSpeed;
        }
    }
}

