using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemigo : MonoBehaviour
{
    bool Chocado;
    public float Velocidad;
    GameObject Lloros;
    // Start is called before the first frame update
    void Start()
    {
        Chocado = false;
        Lloros = GameObject.Find("Lloros");
        Velocidad = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Chocado == false)
        {
            transform.Translate(Vector2.right * Velocidad * Time.deltaTime);
        }
        if (Chocado == true)
        {   // Por algún motivo si le pongo * Velocidad, deja de pillar a "Lloros"
            transform.Translate(Vector2.left * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paredes")
        {
            Chocado = true;
        }
        else
        {
            Chocado = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lloros")
        {
            Chocado = false;
        }
    }
}
