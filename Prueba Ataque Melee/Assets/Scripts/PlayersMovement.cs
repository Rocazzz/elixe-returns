using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject[] players;
    [SerializeField] private float speed;
    public int cantidadPociones, cantidadCofres;
    [SerializeField] private bool isOnBattle;
    public int dinero;
    
    //Cree un Vector Value para guardan la posicion de personajes luego de transicionar
    [SerializeField] private VectorValue startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.zero;
        if(AlmacenarUltimaPosicion.ultimaPosicion == null)
        {
            transform.position = startingPosition.initialValue;
        }
        else
        {
            transform.position = AlmacenarUltimaPosicion.ultimaPosicion;
        }
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if(!isOnBattle)
        {
            moverse();
            rotar();
        }
        else if(isOnBattle)
        {
            transform.position = new Vector3(-5.5f, -1.8f, 0);
        }
    }

    public void moverse()
    {
        //Se a�ade velocidad seg�n la direcci�n que se presione
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
            //Se establece la rotaci�n por defecto si se est� moviendo hacia la derecha
            foreach (GameObject player in players)
            {
                player.GetComponent<Transform>().localScale = new Vector3 (1, 1, 1);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //Se invierte la imagen sobre el eje x si se est� moviendo hacia la izquierda
            foreach (GameObject player in players)
            {
                player.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemigo"))
        {
            SceneManager.LoadScene("Batalla");
        }
    }
}
