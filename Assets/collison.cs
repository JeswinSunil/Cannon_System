using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collison : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("bullet hit");
            Destroy(gameObject);
        }
    }
}
