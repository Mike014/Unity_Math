using UnityEngine;

[RequireComponent(typeof(AudioSource))] // Forces Unity to add an AudioSource if missing
public class AmbisonicVolume : MonoBehaviour
{
    [Header("Geometric Definition (Bounding Sphere)")]
    public Vector3 centerPoint = new Vector3(0, 5, 0); 
    public Vector3 surfacePoint = new Vector3(0, 5, 5); 

    [Header("Ambisonics Simulation")]
    public Transform listener;
    
    // Reference to the actual audio component
    private AudioSource _audioSource;
    private float _radius; 

    void Start()
    {
        // Retrieve the AudioSource component attached to the same object
        _audioSource = GetComponent<AudioSource>();
        
        // Basic configuration for the test
        _audioSource.spatialBlend = 1.0f; // 1.0 = Fully 3D (crucial for spread)
        _audioSource.loop = true;         // Loop sound for easier testing
        _audioSource.dopplerLevel = 0;    // Disable doppler for test purity

        if (listener == null && Camera.main != null)
            listener = Camera.main.transform;
            
        // Initial radius calculation
        _radius = Vector3.Distance(centerPoint, surfacePoint);
        
        // Set the AudioSource max distance to match our sphere + a margin
        // (We disable Unity's curve to use our custom logic in Update)
        _audioSource.maxDistance = _radius * 2; 
    }

    void Update()
    {
        // 1. Recalculate Radius (in case points are moved at runtime)
        _radius = Vector3.Distance(centerPoint, surfacePoint);

        if (listener == null) return;

        // 2. Calculate Listener Distance
        float distanceToListener = Vector3.Distance(centerPoint, listener.position);

        // Local variables for calculation
        float finalVolume = 0f;
        float finalSpread = 0f;

        // 3. HEURISTIC LOGIC (Paper Logic)
        if (distanceToListener <= _radius)
        {
            // --- INSIDE (NEAR-FIELD / NFC) ---
            // You are inside the "emissive volume". 
            // Sound does not decay; it is enveloping.
            
            finalVolume = 1.0f; 
            finalSpread = 360f; // Sound diffused across all speakers (non-directional)
        }
        else
        {
            // --- OUTSIDE (FAR-FIELD) ---
            // You are outside. Sound decays with distance.
            
            // Linear Attenuation Formula (simplified for testing)
            // Value is 1 at the sphere edge, 0 at double the distance
            float normalizedDist = (distanceToListener - _radius) / _radius;
            float attenuation = 1.0f - Mathf.Clamp01(normalizedDist);
            
            finalVolume = attenuation;
            
            // The further you go, the more the spread drops to 0 (becomes a point source)
            finalSpread = Mathf.Lerp(360f, 0f, 1 - attenuation);
        }

        // 4. HARDWARE APPLICATION (AudioSource)
        _audioSource.volume = finalVolume;
        _audioSource.spread = finalSpread; // Maps Ambisonic spread to Unity spread
    }

    void OnDrawGizmos()
    {
        // (Visual feedback for Gizmos)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(centerPoint, surfacePoint);

        Gizmos.color = new Color(0, 1, 1, 0.3f); 
        float r = Vector3.Distance(centerPoint, surfacePoint);
        Gizmos.DrawWireSphere(centerPoint, r);
        
        if (Application.isPlaying && listener != null)
        {
            float d = Vector3.Distance(centerPoint, listener.position);
            if (d <= r)
            {
                Gizmos.color = new Color(0, 1, 0, 0.5f); 
                Gizmos.DrawSphere(centerPoint, r);
            }
            else
            {
                Gizmos.color = Color.yellow; 
                Gizmos.DrawLine(centerPoint, listener.position); 
            }
        }
    }
}

/*
Usage GuideTo apply this experimental methodology within a Unity project:
Script Creation: Create a new C# file named AmbisonicVolume and paste the provided code.
Object Setup: Create an Empty GameObject in the scene (e.g., "Forest_Source") and attach the script to it.
Audio Configuration: Unity will automatically add an AudioSource component. 
Assign an audio clip (e.g., wind or forest ambience) to the AudioClip field and ensure "Play On Awake" is checked.
Geometric Definition: In the AmbisonicVolume component, adjust the Center Point and Surface Point vectors. 
The distance between these two points will automatically define the radius ($R$) of your sound sphere.
Runtime Testing: Play the scene. 
Move the Main Camera (the listener) and observe how the Gizmos change color (Yellow/Green) and hear how the sound transitions from a point source to an enveloping volume as you cross the sphere's boundary.
*/