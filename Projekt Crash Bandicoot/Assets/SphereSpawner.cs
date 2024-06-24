using System.Collections;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Obiekt do respawnu
    public float spawnAreaMinX; // Minimalna wspó³rzêdna X obszaru respawnu
    public float spawnAreaMaxX; // Maksymalna wspó³rzêdna X obszaru respawnu
    public float spawnY; // Sta³a wspó³rzêdna Y
    public float spawnZ; // Sta³a wspó³rzêdna Z
    public float spawnInterval = 4.0f; // Interwa³ czasowy respawnu
    public Coroutine spawn;

    void Start()
    {
        spawn = StartCoroutine(SpawnRoutine());
        // Inicjalizacja pierwszej kuli
        //StartCoroutine(SpawnRoutine());
    }

    //private void Update()
    //{
    //    if (spawn != null)
    //    {
    //        spawn = null;
    //        spawn = StartCoroutine(SpawnRoutine());
    //    }
    //}

    IEnumerator SpawnRoutine()
    {
        while (true) {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Generowanie losowej wspó³rzêdnej X w obszarze respawnu
        float randomX = Random.Range(spawnAreaMinX, spawnAreaMaxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, spawnZ);

        // Respawn obiektu
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    //public void SpawnObject2() { 
    //    Instantiate()
    //}
}
