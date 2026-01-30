using UnityEngine;

public class BoundingBox3DCollision : MonoBehaviour
{
    [Header("Cubo A (es. Taxi)")]
    public Vector3 cubeAPos = new Vector3(0, 0, 0);
    public Vector3 cubeASize = new Vector3(2, 2, 2);
    public Vector3 cubeAOffset = new Vector3(0, 1, 0); // Offset per alzare il centro

    [Header("Cubo B (es. Car)")]
    public Vector3 cubeBPos = new Vector3(1.5f, 0, 0);
    public Vector3 cubeBSize = new Vector3(2, 2, 2);
    public Vector3 cubeBOffset = new Vector3(0, 1, 0);

    void Start()
    {
        // 1. APPLICHIAMO L'OFFSET AL CENTRO
        // Il nuovo centro è: Posizione + Offset
        Vector3 centerA = cubeAPos + cubeAOffset;
        Vector3 centerB = cubeBPos + cubeBOffset;

        // 2. CALCOLIAMO MIN E MAX USANDO IL CENTRO "OFFSATTATO"
        Vector3 halfSizeA = cubeASize * 0.5f;
        Vector3 minA = centerA - halfSizeA;
        Vector3 maxA = centerA + halfSizeA;

        Vector3 halfSizeB = cubeBSize * 0.5f;
        Vector3 minB = centerB - halfSizeB;
        Vector3 maxB = centerB + halfSizeB;

        // 3. LOGICA DI COLLISIONE (SAT su 3 assi)
        if (maxA.x >= minB.x && minA.x <= maxB.x &&
            maxA.y >= minB.y && minA.y <= maxB.y &&
            maxA.z >= minB.z && minA.z <= maxB.z)
        {
            Debug.Log("<color=green>Collisione rilevata con Offset </color>");
        }
        else
        {
            Debug.Log("<color=red>Nessuna collisione </color>");
        }
    }
}

/*
Centro = 0.5 * (PuntaA + PuntoB)

Regola 1: A.Max (1) >= B.Min (0.5)? SÌ (Il Tank finisce dopo l'inizio del Muro).

Regola 2: A.Min (-1) <= B.Max (2.5)? SÌ (Il Tank inizia prima della fine del Muro).

// OFFSET PER CENTRARE BOX
public Vector3 CarCenterOffset = Vector3.zero; 
Vector3 boxCenter = TheCar.transform.localPosition + CarCenterOffset

*/