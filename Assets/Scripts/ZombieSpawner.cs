using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawnRadius;

    public int spawnCount = 1;
    public int spawnTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Запуск таймера
        StartCoroutine("Timer");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        // Генерация точек
        // Случайная точка внутри круга
        Vector3 randPos = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 zombiePos = transform.position + randPos;

        // Спавн зомби
        Instantiate(zombie, zombiePos, Quaternion.identity);
    }

    // Courutine
    // Таймер
    IEnumerator Timer()
    {
        while (true)
        {
            // Ждём
            yield return new WaitForSeconds(spawnTime);
            // Спавним
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnZombie();
            }

        }
    }
}
