using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    // public - возможность изменять переменную из инспектора
    public float speed = 5;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Move()
    {
        // Переменные движения
        float moveX = 0;
        float moveY = 0;

        // Высчитать горизонтальное движение
        // Срабатывает, каждый кадр, пока держим кнопку
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            moveX = 0;
        }

        // Просчет вертикального движения
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            moveY = 0;
        }

        // Вектор движения
        Vector2 move = new Vector2(moveX, moveY).normalized * speed;

        // Применяем вектор на персонажа
        rb.velocity = move;
    }

    void Rotate()
    {
        // Положение мыши на сцене
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Вращение к мыши
        // Меняем up (зеленую стрелку), чтобы она смотрела на мышь
        transform.up = mousePos - transform.position;
        // Сбрасываем x и y
        Vector3 currentRot = transform.rotation.eulerAngles;
        currentRot.x = 0;
        currentRot.y = 0;
        // Применяем исправленное вращение
        transform.rotation = Quaternion.Euler(currentRot);
    }

    void Animate()
    {
        // Задать параметр float
        animator.SetFloat("Speed", rb.velocity.SqrMagnitude());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Animate();
    }
}
