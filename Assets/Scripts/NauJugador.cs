using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    [SerializeField] private float _velNau;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioHorizontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndicada = new Vector2(direccioHorizontal, direccioVertical).normalized;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = spriteRenderer.bounds.size.x / 2;
        float largura = spriteRenderer.bounds.size.y / 2;

        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        float limitArribaY = Camera.main.orthographicSize -largura;
        float limitAbajoY = -Camera.main.orthographicSize +largura;

        Vector2 novaPos = transform.position; //Ens retorna la posicio actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitAbajoY, limitArribaY);

        if (Input.GetKeyDown(KeyCode.Space)){
            shoot();
        }


        transform.position = novaPos;

    }

    private void shoot(){
        GameObject bala = Instantiate(Resources.Load("Prefabs/bala") as GameObject);
        bala.transform.position = this.transform.position;

    }
}