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
        // ������ �������
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
        // ��������� �����
        // ��������� ����� ������ �����
        Vector3 randPos = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 zombiePos = transform.position + randPos;

        // ����� �����
        Instantiate(zombie, zombiePos, Quaternion.identity);
    }

    // Courutine
    // ������
    IEnumerator Timer()
    {
        while (true)
        {
            // ���
            yield return new WaitForSeconds(spawnTime);
            // �������
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnZombie();
            }

        }
    }
}
