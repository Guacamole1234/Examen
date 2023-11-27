using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float Velocidad;
    bool Chocado;
    float tiempo;
    float impulso;
    private SpriteRenderer Rojo;
    private Rigidbody2D Cuerpo;
    // Start is called before the first frame update
    void Start()
    {
        Cuerpo = GetComponent<Rigidbody2D>();
        Rojo = GetComponent<SpriteRenderer>();
        Velocidad = 3f;
        impulso = 3f;


        /*float salto;
        salto = Input.GetKey(Space);
        Cuerpo.AddForce(salto); */
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        if (Chocado == true)
        {
            Rojo.color = Color.red;
            tiempo += Time.deltaTime;
            if (tiempo > 2)
            {
                Chocado = false;
                Rojo.color = Color.green;
            }
        }
        else
        {
            Cuerpo.velocity = new Vector2(movHorizontal * Velocidad, movVertical * Velocidad);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstáculos")
        {
            Chocado = true;
            tiempo = 0;
            Cuerpo.AddForce(collision.GetContact(0).normal * impulso);
        }
    }
}
