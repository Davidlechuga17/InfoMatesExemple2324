using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocity = 5f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y += velocity * Time.deltaTime;
        transform.position = novaPos;

        float limitArribaY = Camera.main.orthographicSize;

        if (novaPos.y >= limitArribaY)
        {
            Destroy(gameObject);
        }

    }
    public void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if(objecteTocat.tag == "Numero")
        {
            Destroy(gameObject);
        }
    }
}
