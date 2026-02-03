using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    // Impostiamo dei valori di default per vederli subito
    public Vector3 A = new Vector3(1, 0, 0); // Destra
    public Vector3 B = new Vector3(0, 0, 1); // Avanti

    // Variabile per vedere il risultato nell'Inspector
    [SerializeField] private Vector3 C; 

    void Update()
    {
        // Calcolo continuo (per debug log)
        C = Vector3.Cross(A, B);
        Debug.Log("Cross Product : " + C);
    }

    void OnDrawGizmos()
    {
        // Definiamo un punto di partenza comodo (la posizione dell'oggetto)
        Vector3 origin = transform.position;

        // Ricalcoliamo C anche qui per vederlo in Editor mode senza premere Play
        Vector3 result = Vector3.Cross(A, B);

        // --- 1. Disegniamo il Vettore A (Verde) ---
        Gizmos.color = Color.green;
        // Disegna una linea da "Qui" a "Qui + Spostamento A"
        Gizmos.DrawLine(origin, origin + A); 
        // Disegno una sferetta alla punta per capire dov'è la "Testa"
        Gizmos.DrawSphere(origin + A, 0.1f);

        // --- 2. Disegniamo il Vettore B (Blu) ---
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(origin, origin + B);
        Gizmos.DrawSphere(origin + B, 0.1f);

        // --- 3. Disegniamo il RISULTATO C (Rosso - Cross Product) ---
        Gizmos.color = Color.red;
        // Questo sarà sempre PERPENDICOLARE agli altri due
        Gizmos.DrawLine(origin, origin + result);
        Gizmos.DrawSphere(origin + result, 0.1f);
    }
}
