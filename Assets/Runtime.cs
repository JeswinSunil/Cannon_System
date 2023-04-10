using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runtime : MonoBehaviour

{
    public GameObject Myprefab;
    public int n = 10;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjects = new GameObject[n];
        for (int i = 0; i < n; i++)
        {


            gameObjects[i] = Instantiate(Myprefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
        }

    }
    
}
