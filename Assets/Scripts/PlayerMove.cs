using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    // public - ����������� �������� ���������� �� ����������
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
        // ���������� ��������
        float moveX = 0;
        float moveY = 0;

        // ��������� �������������� ��������
        // �����������, ������ ����, ���� ������ ������
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

        // ������� ������������� ��������
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

        // ������ ��������
        Vector2 move = new Vector2(moveX, moveY).normalized * speed;

        // ��������� ������ �� ���������
        rb.velocity = move;
    }

    void Rotate()
    {
        // ��������� ���� �� �����
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �������� � ����
        // ������ up (������� �������), ����� ��� �������� �� ����
        transform.up = mousePos - transform.position;
        // ���������� x � y
        Vector3 currentRot = transform.rotation.eulerAngles;
        currentRot.x = 0;
        currentRot.y = 0;
        // ��������� ������������ ��������
        transform.rotation = Quaternion.Euler(currentRot);
    }

    void Animate()
    {
        // ������ �������� float
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
