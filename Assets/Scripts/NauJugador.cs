using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    [SerializeField] private float _velNau;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();

        DispararBala();
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        //Quan la nau toqui un objecte, automaticament es cridara al metode
        //El valor de objecteTocat, sera l'objecte que hem tocat (per exemple, un numero)
        if (objecteTocat.tag == "Numero") 
        {
            Destroy(gameObject);        
        }
    }

    private void MovimentNau() 
    {
        float direccioHorizontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndicada = new Vector2(direccioHorizontal, direccioVertical).normalized;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = spriteRenderer.bounds.size.x / 2;
        float largura = spriteRenderer.bounds.size.y / 2;

        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        float limitArribaY = Camera.main.orthographicSize - largura;
        float limitAbajoY = -Camera.main.orthographicSize + largura;

        Vector2 novaPos = transform.position; //Ens retorna la posicio actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitAbajoY, limitArribaY);

        transform.position = novaPos;
    }

    private void DispararBala() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bala = Instantiate(Resources.Load("Prefabs/bala") as GameObject);
            bala.transform.position = transform.position;
        }
    }
    
}