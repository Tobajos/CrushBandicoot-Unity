using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Prefab kuli
    public Transform spawnPoint;    // Punkt spawnu
    public float spawnInterval = 2f; // Czas miêdzy spawnami w sekundach

    private GameObject currentSphere; // Aktualna kula
    private float timer;              // Timer do kontrolowania spawnowania

    void Start()
    {
        // Inicjalizacja pierwszej kuli
        SpawnSphere();
    }

    void Update()
    {
        // Aktualizacja timera
        timer += Time.deltaTime;

        // Sprawdzenie, czy min¹³ czas do kolejnego spawnu
        if (timer >= spawnInterval)
        {
            // Zresetowanie timera
            timer = 0f;

            // Spawn nowej kuli i zniszczenie starej
            if (currentSphere != null)
            {
                Destroy(currentSphere);
            }
            SpawnSphere();
        }
    }

    void SpawnSphere()
    {
        // Spawn nowej kuli
        currentSphere = Instantiate(spherePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
