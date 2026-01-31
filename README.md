# Unity Math Lab

Un laboratorio didattico per apprendere i concetti fondamentali della matematica 3D in Unity attraverso script interattivi e tecniche di debug visivo.

## Panoramica

Questo progetto è stato creato come risorsa educativa per comprendere la matematica alla base dello sviluppo di videogiochi, in particolare per quanto riguarda la **collision detection** e le operazioni vettoriali.

## Requisiti

- **Unity**: 2022.3.62f3 (LTS) o superiore
- **Linguaggio**: C#

## Struttura del Progetto

```
Assets/
├── Scripts/
│   ├── Bounding Box/       # Script per collision detection AABB
│   └── Bounding Spheres/   # Script per collision detection sferico
└── Scenes/
    └── SampleScene.unity   # Scena dimostrativa
```

## Concetti Matematici

### Bounding Box (AABB)

La cartella `Bounding Box` contiene 5 script che implementano la collision detection tramite **Axis-Aligned Bounding Box**:

| Script | Descrizione |
|--------|-------------|
| `BoundingBox3D.cs` | Calcola le proprietà di un bounding box 3D (centro, dimensioni) |
| `BoundingBox3DCollision.cs` | Implementa la collision detection AABB con confronto Min/Max |
| `IntervalMinMax.cs` | Verifica se un punto è contenuto in un volume 3D |
| `IntervalOverlap.cs` | Rileva la sovrapposizione di intervalli 1D e calcola l'intersezione |
| `SimpleCollision.cs` | Wrapper che utilizza `Bounds.Intersects()` di Unity |

**Concetti chiave:**
- Aritmetica vettoriale (addizione, sottrazione)
- Calcolo Min/Max
- Separating Axis Theorem (SAT)
- Logica di sovrapposizione intervalli

### Bounding Spheres

La cartella `Bounding Spheres` contiene 5 script per la collision detection basata su sfere:

| Script | Descrizione |
|--------|-------------|
| `Sphere.cs` | Calcolo della distanza tra due punti |
| `DistanceBetweenTwoPositions.cs` | Dimostra il calcolo della distanza (manuale e con Unity) |
| `FindRadius.cs` | Calcola il raggio di una sfera dal centro e punti sulla superficie |
| `IsInsideOutside.cs` | Verifica se un punto è dentro o fuori una sfera |
| `SphereVSSphere.cs` | Template per collision sfera-sfera |

**Concetti chiave:**
- Formula della distanza 3D (distanza euclidea)
- Teorema di Pitagora esteso a 3 dimensioni
- Calcolo della magnitudine di un vettore
- Test punto-in-sfera

## Formule Matematiche

### Distanza tra due punti
```
d = √[(x₂-x₁)² + (y₂-y₁)² + (z₂-z₁)²]
```

### Collision AABB
Due bounding box collidono se si sovrappongono su tutti e tre gli assi:
```
collisione = (A.min.x ≤ B.max.x && A.max.x ≥ B.min.x) &&
             (A.min.y ≤ B.max.y && A.max.y ≥ B.min.y) &&
             (A.min.z ≤ B.max.z && A.max.z ≥ B.min.z)
```

### Collision Sfera-Sfera
Due sfere collidono se la distanza tra i centri è minore della somma dei raggi:
```
collisione = distanza(centroA, centroB) < raggioA + raggioB
```

## Debug Visivo

Il progetto utilizza estensivamente i **Gizmos** di Unity per la visualizzazione:

- `Gizmos.DrawCube()` / `Gizmos.DrawWireCube()` - Bounding box
- `Gizmos.DrawSphere()` / `Gizmos.DrawWireSphere()` - Sfere
- `Gizmos.DrawLine()` - Linee e distanze
- Feedback cromatico: **verde** = nessuna collisione, **rosso** = collisione

## Come Utilizzare

1. Apri il progetto in Unity
2. Carica la scena `SampleScene`
3. Seleziona gli oggetti nella scena per vedere i parametri nell'Inspector
4. Premi Play e osserva i Gizmos nella vista Scene
5. Modifica i parametri in tempo reale per sperimentare

## Obiettivi Didattici

- Comprendere come funziona la collision detection a livello matematico
- Operazioni vettoriali e la loro interpretazione geometrica
- Calcoli di distanza e magnitudine nello spazio 3D
- Differenze tra approcci AABB e sferico
- Tecniche di debug visivo per algoritmi spaziali

## Autore

Progetto creato come esercizio didattico per il corso Epicode.

## Licenza

Questo progetto è destinato esclusivamente a scopi educativi.
