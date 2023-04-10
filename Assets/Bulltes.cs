using UnityEngine;
using System.Collections.Generic;

public class Bulltes : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public Transform firePoint;
    public float fireForce = 50f;
    public int poolSize = 10;
    public float fireDelay = 1f;

    private List<GameObject> cannonBallPool;
    private float lastFireTime = 0f;

    void Start()
    {
        // Initialize the cannon ball object pool
        cannonBallPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab);
            cannonBall.SetActive(false);
            cannonBallPool.Add(cannonBall);
        }
    }

    void Update()
    {
        // Check if it's time to fire
        if (Time.time - lastFireTime > fireDelay)
        {
            // Fire a cannon ball
            FireCannonBall();
            lastFireTime = Time.time;
        }
    }

    void FireCannonBall()
    {
        // Find a disabled cannon ball in the pool and fire it from the fire point
        GameObject cannonBall = cannonBallPool.Find(ball => !ball.activeInHierarchy);
        if (cannonBall != null)
        {
            cannonBall.transform.position = firePoint.position;
            cannonBall.transform.rotation = firePoint.rotation;
            cannonBall.SetActive(true);

            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddRelativeForce(Vector3.forward * fireForce);
        }
    }
}
