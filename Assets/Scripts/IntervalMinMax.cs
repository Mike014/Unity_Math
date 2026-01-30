using UnityEngine;

public class IntervalMinMax : MonoBehaviour
{
    public Transform playerBall; 

    [Header("Limiti Asse Y (Altezza)")]
    public float laserMinY = 1.0f; 
    public float laserMaxY = 3.0f; 

    [Header("Limiti Asse X (Larghezza)")]
    public float laserMinX = 1.0f; 
    public float laserMaxX = 3.0f; 

    [Header("Limiti Asse Z (Profondità)")]
    public float laserMinZ = 1.0f; 
    public float laserMaxZ = 3.0f; 

    void Update()
    {
        Vector3 pos = playerBall.position;

        // 1. Sei dentro la larghezza giusta?
        bool insideX = (pos.x >= laserMinX) && (pos.x <= laserMaxX);

        // 2. Sei all'altezza giusta?
        bool insideY = (pos.y >= laserMinY) && (pos.y <= laserMaxY);

        // 3. Sei alla profondità giusta?
        bool insideZ = (pos.z >= laserMinZ) && (pos.z <= laserMaxZ);

        // LA LOGICA FINALE:
        // Deve essere vero X *E* vero Y *E* vero Z contemporaneamente.
        // Basta che uno sia falso per essere fuori dalla scatola.
        if (insideX && insideY && insideZ)
        {
            Debug.Log("⚠️ ALLARME! Sei DENTRO il volume proibito!");
        }
        else
        {
            // Opzionale: Debug per capire dove sei fuori
            Debug.Log($"Stato: X={insideX}, Y={insideY}, Z={insideZ}");
        }
    }

    // Disegniamo la scatola per vederla (Gizmos è meglio di 12 DrawLine!)
    void OnDrawGizmos()
    {
        // Calcoliamo il centro e la dimensione della scatola basandoci sui tuoi Min/Max
        // Matematica: Centro = (Max + Min) / 2
        // Matematica: Dimensione = Max - Min
        
        Vector3 center = new Vector3(
            (laserMinX + laserMaxX) / 2,
            (laserMinY + laserMaxY) / 2,
            (laserMinZ + laserMaxZ) / 2
        );

        Vector3 size = new Vector3(
            laserMaxX - laserMinX,
            laserMaxY - laserMinY,
            laserMaxZ - laserMinZ
        );

        // Se il giocatore è dentro (lo ricalcolo qui per il colore), diventa ROSSO
        bool isInside = false;
        if (playerBall != null)
        {
            Vector3 pos = playerBall.position;
            isInside = (pos.x >= laserMinX && pos.x <= laserMaxX) &&
                       (pos.y >= laserMinY && pos.y <= laserMaxY) &&
                       (pos.z >= laserMinZ && pos.z <= laserMaxZ);
        }

        Gizmos.color = isInside ? new Color(1, 0, 0, 0.5f) : new Color(0, 1, 0, 0.5f);
        
        // Disegna il cubo pieno (trasparente)
        Gizmos.DrawCube(center, size);
        
        // Disegna il bordo (filo di ferro)
        Gizmos.color = isInside ? Color.red : Color.green;
        Gizmos.DrawWireCube(center, size);
    }
}