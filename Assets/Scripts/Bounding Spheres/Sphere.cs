using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Immaginiamo la sfera così:
    [Header("Definizione Sfera")]
    public Vector3 puntoA = new Vector3(0, 5, 0);  // Consideriamolo il CENTRO (C)
    public Vector3 puntoB = new Vector3(1, 10, 0); // Consideriamolo un punto sulla SUPERFICIE (P)

    void Start()
    {
        // --- CALCOLO DEL RAGGIO ---
        // Definizione Geometrica: Il raggio è la distanza tra il Centro e un punto qualsiasi sulla superficie.
        // Formula: r = |P - C| (Magnitudine del vettore differenza)
        
        float distanza = Vector3.Distance(puntoA, puntoB);
        
        // In questo contesto, la "distanza" È il raggio.
        float radius = distanza; 

        Debug.Log("La distanza tra Centro e Superficie è: " + distanza);
        Debug.Log("Quindi il Raggio della sfera è: " + radius);
    }

    void Update()
    {
        // Visualizzazione grafica nella Scene View per capire il concetto
        // Disegna il RAGGIO in rosso
        Debug.DrawLine(puntoA, puntoB, Color.red);
    }
    
    /* * SPIEGAZIONE MATEMATICA:
     * 1. Hai due punti nello spazio.
     * 2. Se decidi che puntoA è il centro della tua sfera immaginaria...
     * 3. ...e decidi che la sfera deve toccare esattamente puntoB...
     * 4. Allora la distanza euclidea (Pitagora 3D) tra A e B diventa automaticamente il tuo Raggio.
     */
}


