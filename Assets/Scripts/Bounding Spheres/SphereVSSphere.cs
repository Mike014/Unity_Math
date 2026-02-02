using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVSSphere : MonoBehaviour
{
    // Immaginiamo la sfera così:
    [Header("Definizione SferaA")]
    public Vector3 a_puntoA = new Vector3(0, 5, 0);  // Consideriamolo il CENTRO (C)
    public Vector3 a_puntoB = new Vector3(1, 10, 0); // Consideriamolo un punto sulla SUPERFICIE (P)

    [Header("Definizione SferaB")]
    public Vector3 b_puntoA = new Vector3(0, 10, 0);  // Consideriamolo il CENTRO (C)
    public Vector3 b_puntoB = new Vector3(2, 20, 0); // Consideriamolo un punto sulla SUPERFICIE (P)

    private float radius_A;
    private float radius_B;

    void Start()
    {
        // --- CALCOLO DEL RAGGIO (All'avvio del gioco) ---
        radius_A = Vector3.Distance(a_puntoA, a_puntoB);
        radius_B = Vector3.Distance(b_puntoA, b_puntoB);

        Debug.Log("Raggio A: " + radius_A);
        Debug.Log("Raggio B: " + radius_B);
    }

    void Update()
    {
        /* NOTA PER MICHELE: 
         * Se vuoi che la collisione funzioni anche se muovi i punti DURANTE il gioco,
         * dovresti ricalcolare radius_A e radius_B qui dentro, prima del check.
         */

        // 1. Calcola la distanza tra i due CENTRI
        float centerDistance = Vector3.Distance(a_puntoA, b_puntoA);

        // 2. Verifica la collisione: Distanza Centri <= Somma Raggi
        if (centerDistance <= radius_A + radius_B)
        {
            Debug.Log("Collisione Rilevata! 💥");
        }
        else
        {
            Debug.Log("No Collision!!");
        }
    }

    // ========================================================
    //  👇 NUOVA PARTE: VISUALIZZAZIONE GIZMOS 👇
    // ========================================================
    void OnDrawGizmos()
    {
        // 1. Ricalcoliamo i raggi "al volo" per vederli nell'Editor anche senza premere Play
        float rA = Vector3.Distance(a_puntoA, a_puntoB);
        float rB = Vector3.Distance(b_puntoA, b_puntoB);

        // 2. Calcoliamo la collisione "visiva"
        float distCenters = Vector3.Distance(a_puntoA, b_puntoA);
        bool isColliding = distCenters <= (rA + rB);

        // 3. Impostiamo il colore: ROSSO se tocca, VERDE se sicuro
        if (isColliding)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        // --- DISEGNO SFERA A ---
        Gizmos.DrawWireSphere(a_puntoA, rA);          // Il cerchio esterno
        Gizmos.DrawLine(a_puntoA, a_puntoB);          // Il raggio (dal centro alla superficie)
        Gizmos.DrawSphere(a_puntoA, 0.1f);            // Un puntino per il centro

        // --- DISEGNO SFERA B ---
        Gizmos.DrawWireSphere(b_puntoA, rB);
        Gizmos.DrawLine(b_puntoA, b_puntoB);
        Gizmos.DrawSphere(b_puntoA, 0.1f);

        // --- DISEGNO LA DISTANZA TRA I CENTRI ---
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(a_puntoA, b_puntoA);
    }

    /*
    Codice con logica di Disegno Gizmo errato
    */
}