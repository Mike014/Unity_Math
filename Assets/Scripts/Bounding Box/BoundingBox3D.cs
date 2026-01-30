using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox3D : MonoBehaviour
{
    public Vector3 minPos = new Vector3(-5, 0, -5);
    public Vector3 maxPos = new Vector3(5, 10, 5); 

    // Start is called before the first frame update
    void Start()
    {
        CreateBoundingBox3D();
    }

    // Update is called once per frame
    void Update()
    {
        CreateBoundingBox3D();
    }

    void CreateBoundingBox3D()
    {
        Vector3 Center = 0.5f * (minPos + maxPos);
        Debug.Log("Center : " + Center);

        Vector3 Size = maxPos - minPos; 
        Debug.Log("Size : " + Size);
    }
}

