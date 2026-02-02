using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBounds : MonoBehaviour
{
    public Bounds bounds;

    void Start()
    {
        // Crea un Bounds centrato sulla posizione dell'oggetto con dimensione 1x1x1 [1]
        if (bounds.size == Vector3.zero) // Vector3.one è una scorciatoia per scrivere (1, 1, 1)
        {
            bounds = new Bounds(transform.position, Vector3.one);
        }
    }

    void Update()
    {
        // Controlla se un punto è dentro il box
        Vector3 testPoint = new Vector3(0, 0, 0);
        if (bounds.Contains(testPoint))
        {
            Debug.Log("Punto dentro il box");
        }
    }

    void DrawBounds(Bounds b, Color color)
    {
        Vector3 min = b.min;
        Vector3 max = b.max;

        Vector3[] corners = new Vector3[8];
        // Bottom
        corners[0] = new Vector3(min.x, min.y, min.z);
        corners[1] = new Vector3(max.x, min.y, min.z);
        corners[2] = new Vector3(max.x, min.y, max.z);
        corners[3] = new Vector3(min.x, min.y, max.z);
        // Top
        corners[4] = new Vector3(min.x, max.y, min.z);
        corners[5] = new Vector3(max.x, max.y, min.z);
        corners[6] = new Vector3(max.x, max.y, max.z);
        corners[7] = new Vector3(min.x, max.y, max.z);

        // Bottom rectangle
        Debug.DrawLine(corners[0], corners[1], color);
        Debug.DrawLine(corners[1], corners[2], color);
        Debug.DrawLine(corners[2], corners[3], color);
        Debug.DrawLine(corners[3], corners[0], color);

        // Top rectangle
        Debug.DrawLine(corners[4], corners[5], color);
        Debug.DrawLine(corners[5], corners[6], color);
        Debug.DrawLine(corners[6], corners[7], color);
        Debug.DrawLine(corners[7], corners[4], color);

        // Vertical edges
        Debug.DrawLine(corners[0], corners[4], color);
        Debug.DrawLine(corners[1], corners[5], color);
        Debug.DrawLine(corners[2], corners[6], color);
        Debug.DrawLine(corners[3], corners[7], color);
    }
}
