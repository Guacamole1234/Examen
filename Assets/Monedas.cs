using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    bool dinero;
    GameObject Muro;
    // Start is called before the first frame update
    void Start()
    {
        Muro = GameObject.Find("Muro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "Monedas")
        {
            dinero = true;
        }
        else
        {
            dinero = false;
        }
        if (dinero == false)
        {
            Destroy(Muro);
        }
    }
}
