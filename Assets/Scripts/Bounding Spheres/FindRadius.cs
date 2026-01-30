using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRadius : MonoBehaviour
{
    Vector3 center = Vector3.zero;
    Vector3[] vertices;

    // Update is called once per frame
    void Update()
    {
        foreach (Vector3 point in vertices)
        {
            // 1. Crea il vettore dal centrao al punto
            Vector3 direction = point - center;

            // 2. Calcola la lunghezza al quadrato (OTTIMIZZAZIONE!)
            //DA COMPLETARE
        }
        
    }
}

/*
Partendo dal 2D
Il Concetto Vettoriale (2D)
1. Centro (C)
2. Punto su bordo oggetto (P)
3. Raggio (r) che è la lunghezza del vettore differenza tra P e C

Formula Vettorial

V = P - C
r = |V| (Magnitude)

Visivamente:
- C è l'origine del vettore.
- P è la punta della freccia.
- La lunghezza della freccia è il raggio.

      y
     |
     |
     | C
    / \ 
   /   \
z /     \ x 
   P

*/
