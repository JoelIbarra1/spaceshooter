using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; // Intervalo de aparici�n de enemigos
    public float spawnRangeX = 10f; // Rango horizontal de aparici�n
    public Vector3 spawnRotation = new Vector3(0, -180, 0);

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Posici�n de aparici�n en un rango aleatorio en X, arriba de la pantalla
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), transform.position.y, transform.position.z);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(spawnRotation));
    }
}
