using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject[] players;
    [SerializeField] private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moverse();
        rotar();
    }

    public void moverse()
    {
        //Se añade velocidad según la dirección que se presione
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //Se invocan las animaciones de los personajes
            foreach(GameObject player in players)
            {
                player.GetComponent<Animator>().SetTrigger("run");
            }
        }
        else if(Input.GetAxisRaw("Horizontal") == 0)
        {
            //Se invocan las animaciones de los personajes
            foreach (GameObject player in players)
            {
                player.GetComponent<Animator>().SetTrigger("idle");
            }
        }
    }

    public void rotar()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //Se establece la rotación por defecto si se está moviendo hacia la derecha
            foreach (GameObject player in players)
            {
                player.GetComponent<Transform>().localScale = new Vector3 (1, 1, 1);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //Se invierte la imagen sobre el eje x si se está moviendo hacia la izquierda
            foreach (GameObject player in players)
            {
                player.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
