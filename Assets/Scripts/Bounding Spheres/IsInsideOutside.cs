using UnityEngine;

public class SphereCheck : MonoBehaviour
{
    [Header("Configurazione Sfera")]
    public float sphereRadius = 3.0f; // Il Raggio (R)
    public Transform targetPoint;     // Il Punto da testare (P)

    [Header("Feedback Visivo")]
    public Color safeColor = Color.green; // Colore quando è FUORI
    public Color hitColor = Color.red;    // Colore quando è DENTRO

    // Variabile per memorizzare il risultato (solo per debug)
    [SerializeField] private bool isInside = false;
    [SerializeField] private float currentDistance = 0f;

    void Update()
    {
        if (targetPoint == null) return;

        // --- 1. IL CALCOLO MATEMATICO (La tua formula) ---
        
        // Calcoliamo il vettore differenza (La freccia dal Centro al Punto)
        Vector3 difference = targetPoint.position - transform.position;

        // Calcoliamo la lunghezza di quella freccia (Magnitudine) // (x*x+y*y+z*z)
        // currentDistance = difference.distance(targetPoint.position, transform.position)
        currentDistance = difference.magnitude;

        // --- 2. IL TEST LOGICO (Inside-Outside) ---
        
        // Se la distanza è minore o uguale al raggio...
        if (currentDistance <= sphereRadius)
        {
            isInside = true;  // CONTATTO!
            Debug.Log("COLLISIONE! Il punto è DENTRO la sfera.");
        }
        else
        {
            isInside = false; // SICURO
        }
    }

    // --- 3. VISUALIZZAZIONE (Disegniamo la matematica) ---
    private void OnDrawGizmos()
    {
        // Disegna una linea che rappresenta la distanza corrente
        if (targetPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, targetPoint.position);
        }

        // Scegli il colore in base al risultato del test
        if (isInside)
        {
            Gizmos.color = hitColor; // Rosso
        }
        else
        {
            Gizmos.color = safeColor; // Verde
        }

        // Disegna la sfera "invisibile" (WireSphere)
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}