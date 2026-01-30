using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollision : MonoBehaviour
{
    // Riferimenti ai collider reali nella scena
    public Collider oggettoA;
    public Collider oggettoB;

    // Colore per visualizzare la "Scatola" quando non si toccano
    public Color safeColor = Color.blue;
    // Colore quando c'è collisione
    public Color hitColor = Color.red;

    // BEST PRACTICE: Visual Debugging
    // Questo metodo disegna forme nell'editor anche se il gioco non è in play,
    // o per mostrare cose invisibili come i Bounds.
    void OnDrawGizmos()
    {
        // Se non abbiamo assegnato gli oggetti, non fare nulla per evitare errori
        if (oggettoA == null || oggettoB == null) return;

        // Ricalcoliamo i bounds attuali
        Bounds boxA = oggettoA.bounds;
        Bounds boxB = oggettoB.bounds;

        // Controlliamo la collisione solo per decidere il colore
        bool isColliding = boxA.Intersects(boxB);

        // Disegniamo la Scatola A
        Gizmos.color = isColliding ? hitColor : safeColor;
        Gizmos.DrawWireCube(boxA.center, boxA.size);

        // Disegniamo la Scatola B
        Gizmos.DrawWireCube(boxB.center, boxB.size);
    }

    // Update viene chiamato ogni frame (il nostro "motore")
    void Update()
    {
        // Otteniamo i Bounds aggiornati dai collider nel mondo
        Bounds boxA = oggettoA.bounds;
        Bounds boxB = oggettoB.bounds;

        // Eseguiamo il controllo (la tua logica originale)
        if (boxA.Intersects(boxB))
        {
            Debug.Log("COLLISIONE! (I due Bounding Box si stanno toccando)");
        }
    }
}

/*
Non serve premere Play! Grazie a OnDrawGizmos, dovresti già vedere due "gabbie" (wireframe) verdi attorno ai cubi nella Scene View.

Seleziona uno dei cubi e muovilo usando lo strumento Move (W) verso l'altro.

Appena le due linee blue si toccano, diventeranno Rosse e (se premi Play) vedrai il messaggio in Console.
*/
