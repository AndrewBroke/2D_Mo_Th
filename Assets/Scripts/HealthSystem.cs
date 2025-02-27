using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    // �� ���� �������?
    // 1. ����������� ��������
    // 2. ��������� ��������
    // 3. �������� ��� ������

    int health;
    public Image healthFiller;
    public UnityEvent onDead;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        // ����� �� UI
        healthFiller.fillAmount = (float)health / 100;
    }

    public void ChangeHealth(int value)
    {
        health = health + value;
        if(health > 100)
        {
            health = 100;
        }
        if (health <= 0)
        {
            health = 0;
            onDead.Invoke();
        }
        healthFiller.fillAmount = (float)health / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
