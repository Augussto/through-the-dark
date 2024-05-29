using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que quieres generar
    public Transform spawnPoint; // Punto donde quieres que aparezcan los enemigos
    public float spawnInterval = 3f; // Intervalo de tiempo entre cada generación de enemigos
    public int maxEnemies = 10; // Número máximo de enemigos en pantalla

    private int currentEnemies = 5; // Contador de enemigos actual
    private Coroutine spawnCoroutine; // Referencia al coroutine de generación

    void Start()
    {
        // Comenzar el coroutine para generar enemigos
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Verificar si no hemos alcanzado el límite de enemigos en pantalla
            if (currentEnemies < maxEnemies)
            {
                // Instanciar un nuevo enemigo en el punto de spawn
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                currentEnemies++; // Incrementar el contador de enemigos

                // Esperar el intervalo de tiempo antes de generar otro enemigo
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                // Si ya hay demasiados enemigos, esperar un poco antes de volver a verificar
                yield return new WaitForSeconds(1f);
            }
        }
    }

    // Método para decrementar el contador de enemigos cuando uno es destruido
    public void EnemyDestroyed()
    {
        currentEnemies--;
    }

    // Método para detener la generación de enemigos
    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}