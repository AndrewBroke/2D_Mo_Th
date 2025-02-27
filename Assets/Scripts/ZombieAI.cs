using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public float speed;

    GameObject player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Rotate()
    {
        // Положение персонажа
        Vector3 playerPos = player.transform.position;

        // Применяем поворот
        transform.right = playerPos - transform.position;
    }

    void Move()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    public void DeadZombie()
    {
        Destroy(gameObject);
    }
}
