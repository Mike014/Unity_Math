using UnityEngine; // Basta questo per Unity

public class DotProduct : MonoBehaviour
{
    [Header("Input Vettori")]
    public Vector3 V1 = new Vector3(1, 0, 0);
    public Vector3 V2 = new Vector3(0.5f, 0.5f, 0);

    [Header("Risultati Monitor")]
    [SerializeField] private float rawDotProduct;       // Dot Product "Grezzo"
    [SerializeField] private float normalizedDotProduct; // Dot Product Normalizzato (Coseno dell'angolo)
    [SerializeField] private Vector3 vectorProjection; // Dot Product Normalizzato (Coseno dell'angolo)

    void Update()
    {
        // 1. Dot Product Standard (dipende dalla lunghezza dei vettori)
        rawDotProduct = Vector3.Dot(V1, V2);
        
        // 2. Dot Product Normalizzato (dipende SOLO dalla direzione/angolo)
        // Il risultato sarà sempre tra -1 e 1
        normalizedDotProduct = Vector3.Dot(V1.normalized, V2.normalized);

        // 3. Proiezioni Vettoriali 
        // V1 projected onto V2
        vectorProjection = Vector3.Project(V1, V2);

        // LOG (Usiamo le parentesi!)
        // Uso un if per non intasare la console ogni frame, premi Spazio per loggare
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Raw: {rawDotProduct} | Normalized: {normalizedDotProduct} | Projection: {vectorProjection}");
        }
    }

    // --- VISUALIZZAZIONE ---
    void OnDrawGizmos()
    {
        // Disegna V1 in Verde
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, V1);

        // Disegna V2 in Blu
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, V2);

        // Visualizza l'angolo approssimativo con il colore del cubo
        // Se > 0 (Verde scuro) guardano stessa parte
        // Se < 0 (Rosso scuro) guardano parti opposte
        Gizmos.color = normalizedDotProduct > 0 ? new Color(0, 1, 0, 0.3f) : new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

/*
Test di Direzione: Un risultato positivo indica un angolo inferiore a 90°, zero indica vettori perpendicolari, e un risultato negativo indica un angolo superiore a 90°
*/