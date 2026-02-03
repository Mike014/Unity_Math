using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 P1;
    public Vector3 P2;

    void Start()
    {
        P1 = Vector3.zero; // (0, 0, 0)
        P2 = Vector3.one; // (1, 1, 1)

        Debug.Log(P1);
        Debug.Log(P2);
    }

    void Update()
    {
        Vector3 _distance = P2 - P1;
        // Debug.Log("Distance is Vector3 _distance = P2 - P1;:" + _distance);

        // Debug.Log("Distance is .magnitude:" + _distance.magnitude);
        
        // Vector3.Dot(A, B) Quanto sono allineate due linee
        float _alignment = Vector3.Dot(P1, P2);
        Debug.Log("Prodotto Scalare : " + _alignment);

        // Vector3.Cross(A, B) Nuove direzioni, Serve a trovare una direzione che sia a 90° rispetto ad altre due.
        Vector3 _perpendicularDirection = Vector3.Cross(P1, P2);
        Debug.Log("Prodotto Cross : " + _perpendicularDirection);
    }

    void OnDrawGizmos()
    {
        // (Visual feedback for Gizmos)
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(P1, P2);
    }
}
