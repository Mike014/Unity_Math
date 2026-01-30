using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // public Vector3 center = new Vector3(0, 5, 0); // Centro 
    // public float radius = 3.0f; // Raggio

    public Vector3 puntoA = new Vector3(0, 5, 0);
    public Vector3 puntoB = new Vector3(1, 10, 0);

    // Start is called before the first frame update
    void Start()
    {
        float distanza = Vector3.Distance(puntoA, puntoB);
        Debug.Log("Distanza è : " + distanza);
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}


