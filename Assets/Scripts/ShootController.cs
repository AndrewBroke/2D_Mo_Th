using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    // Переменная для хранения объекта
    public GameObject bullet;
    public GameObject bulletPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Shoot()
    {
        print("Выстрел");
        Instantiate(bullet, bulletPoint.transform.position, 
            bulletPoint.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
}
