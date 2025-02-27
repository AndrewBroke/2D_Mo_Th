using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHealth : MonoBehaviour
{
    public int value;
    public string checkTag = "";
    public bool destroyOnUse = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверить тег
        if(checkTag == "")
        {
            // Изменяем любого
            HealthSystem hs;
            // Пытаемся получить компонент
            if(collision.gameObject.TryGetComponent(out hs))
            {
                hs.ChangeHealth(value);
            }
            if (destroyOnUse == true)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Проверяем тег
            if (collision.gameObject.tag == checkTag)
            {
                HealthSystem hs;
                // Пытаемся получить компонент
                if (collision.gameObject.TryGetComponent(out hs))
                {
                    hs.ChangeHealth(value);
                }
                if(destroyOnUse == true)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
