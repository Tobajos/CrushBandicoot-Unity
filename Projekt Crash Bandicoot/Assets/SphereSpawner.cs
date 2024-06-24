using System.Collections;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Obiekt do respawnu
    public float spawnAreaMinX; // Minimalna wsp�rz�dna X obszaru respawnu
    public float spawnAreaMaxX; // Maksymalna wsp�rz�dna X obszaru respawnu
    public float spawnY; // Sta�a wsp�rz�dna Y
    public float spawnZ; // Sta�a wsp�rz�dna Z
    public float spawnInterval = 4.0f; // Interwa� czasowy respawnu
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
        // Generowanie losowej wsp�rz�dnej X w obszarze respawnu
        float randomX = Random.Range(spawnAreaMinX, spawnAreaMaxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, spawnZ);

        // Respawn obiektu
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    //public void SpawnObject2() { 
    //    Instantiate()
    //}
}
