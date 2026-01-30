using UnityEngine;

public class IntervalOverlap : MonoBehaviour
{
    [System.Serializable]
    public struct FloatInterval
    {
        public float point1;
        public float point2;

        // Proprietà calcolate per gestire l'inserimento dati errato
        // (es. se l'utente mette il valore maggiore nel campo point1)
        public float Min => Mathf.Min(point1, point2);
        public float Max => Mathf.Max(point1, point2);

        public bool Overlaps(FloatInterval other)
        {
            return Max >= other.Min && Min <= other.Max;
        }

        public float GetOverlapMax(FloatInterval other) => Mathf.Min(Max, other.Max);
        public float GetOverlapMin(FloatInterval other) => Mathf.Max(Min, other.Min);
    }

    [Header("Configurazione Intervalli")]
    public FloatInterval intervalA;
    public FloatInterval intervalB;

    private void Update()
    {
        // Analisi sezione per sezione:
        // 1. Chiamiamo il metodo della struct (Separation of Concerns)
        if (intervalA.Overlaps(intervalB))
        {
            // 2. Calcoliamo i punti di intersezione solo se necessario
            float overlapMin = intervalA.GetOverlapMin(intervalB);
            float overlapMax = intervalA.GetOverlapMax(intervalB);

            Debug.Log($"<color=green>Intersezione!</color> Range: [{overlapMin} , {overlapMax}]");
        }
        else
        {
            // Nota: in un progetto reale, eviteremmo il Log in Update se non c'è collisione
            // per non intasare la console.
        }
    }

    // Visualizzazione visiva nella scena per facilitare il debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        DrawInterval(intervalA, 0.5f);
        
        Gizmos.color = Color.blue;
        DrawInterval(intervalB, -0.5f);
    }

    private void DrawInterval(FloatInterval interval, float yOffset)
    {
        Vector3 start = new Vector3(interval.Min, yOffset, 0);
        Vector3 end = new Vector3(interval.Max, yOffset, 0);
        Gizmos.DrawLine(start, end);
        Gizmos.DrawSphere(start, 0.1f);
        Gizmos.DrawSphere(end, 0.1f);
    }
}

/*
(a) NESSUNA INTERSEZIONE:
    G: |------|
    B:           |------|
    
(b) PARZIALE (G.min dentro B):
    G:     |---------|
    B: |---------|
    O:     |-----|  (overlap)
    
(c) G COMPLETAMENTE DENTRO B:
    G:    |---|
    B: |---------|
    O:    |---|
    
(d) B COMPLETAMENTE DENTRO G:
    G: |---------|
    B:    |---|
    O:    |---|
    
(e) PARZIALE (G.max dentro B):
    G: |---------|
    B:     |---------|
    O:     |-----|
*/