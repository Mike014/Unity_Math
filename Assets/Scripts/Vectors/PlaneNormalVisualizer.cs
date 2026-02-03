using UnityEngine;

public class PlaneNormalVisualizer : MonoBehaviour
{
    [Header("Definisci il Piano (3 Punti)")]
    public Transform pointA;
    public Transform pointB; // Il vertice verso cui va il primo vettore
    public Transform pointC; // Il vertice verso cui va il secondo vettore

    void OnDrawGizmos()
    {
        // Controllo di sicurezza: se non hai assegnato gli oggetti, non fare nulla
        if (pointA == null || pointB == null || pointC == null) return;

        // =========================================================
        // PASSO 1: Dai Punti ai Vettori
        // =========================================================
        // Creiamo due vettori che partono da A e "scorrono" sul piano.
        // Vettore = Destinazione - Origine
        Vector3 vector1 = pointB.position - pointA.position; // Lato AB
        Vector3 vector2 = pointC.position - pointA.position; // Lato AC

        // =========================================================
        // PASSO 2: Calcolo della Normale (CROSS PRODUCT)
        // =========================================================
        // La magia avviene qui. Il risultato è perpendicolare sia a vector1 che a vector2.
        Vector3 normalDirection = Vector3.Cross(vector1, vector2);
        
        // Importante: Normalizziamo per avere una lunghezza standard di 1 (solo direzione)
        Vector3 normalNormalized = normalDirection.normalized;


        // =========================================================
        // VISUALIZZAZIONE
        // =========================================================
        
        // 1. Disegniamo il "Piano" (il Triangolo formato dai 3 punti) in BIANCO
        Gizmos.color = Color.white;
        Gizmos.DrawLine(pointA.position, pointB.position); // Disegna Vettore 1
        Gizmos.DrawLine(pointA.position, pointC.position); // Disegna Vettore 2
        Gizmos.DrawLine(pointB.position, pointC.position); // Chiudi il triangolo

        // 2. Disegniamo la NORMALE calcolata in ROSSO
        // La facciamo partire da PointA per vederla bene
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pointA.position, normalNormalized * 2f); // *2 solo per farla più lunga e visibile
        
        // Disegno una sferetta alla punta della normale per evidenziarla
        Gizmos.DrawSphere(pointA.position + (normalNormalized * 2f), 0.1f);
    }
}