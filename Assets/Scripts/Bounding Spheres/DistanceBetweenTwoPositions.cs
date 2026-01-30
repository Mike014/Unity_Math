using UnityEngine;

public class DistanceBetweenTwoPositions : MonoBehaviour
{
    [Header("Configurazione")]
    public Vector3 D = new Vector3(0, 5, 0); // Puoi modificarlo nell'Inspector!
    
    // Invece di creare una variabile new Vector3(0,0,0), usiamo la scorciatoia di Unity
    private Vector3 origin = Vector3.zero; 

    // Spostiamo i calcoli in Update per vederli in tempo reale
    void Update()
    {
        // --- METODO MANUALE (Pitagora) ---
        float dx = D.x - origin.x;
        float dy = D.y - origin.y;
        float dz = D.z - origin.z;

        // Teorema di Pitagora 3D
        float manualDistance = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);

        // --- METODO UNITY ---
        float autoDistance = Vector3.Distance(D, origin);

        // --- VISUALIZZAZIONE ---
        // Disegna una linea rossa dall'origine al punto D
        Debug.DrawLine(origin, D, Color.red);
        
        // Logga solo se premiamo Spazio (per non intasare la console)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Manuale: {manualDistance} | Automatico: {autoDistance}");
        }
    }
}

/*
Distanza tra due Posizioni (3D)
Teorema di Pitagora dal 2D al 3D

Per trovare la distanza di un punto D(x, y, z) dall'origine (0,0,0)
Triangolo 1 (Base): Calcola l'ipotenusa sul piano terra (X-Y).
Triangolo 2 (Altezza): Usa quell'ipotenusa come base per un nuovo triangolo che include l'altezza (Z).
*/