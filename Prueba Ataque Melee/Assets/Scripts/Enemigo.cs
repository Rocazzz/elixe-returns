using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;

public class Enemigo : Personaje
{
    [SerializeField] private int cantPociones, cantCofres, cantOro;
    [SerializeField] private bool sueltaEscapulario;


    // Start is called before the first frame update
    void Awake()
    {
        foreach (Heroe hero in FindFirstObjectByType<PlayersMovement>().GetComponentsInChildren<Heroe>())
        {
            rivales.Add(hero);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AlmacenarEnemigo.AlmacenarEsteEnemigo(gameObject);
            SceneManager.LoadScene("Batalla");
            Destroy(gameObject);
        }
    }

    public void SoltarDrop()
    {
        PlayersMovement jugador = FindObjectOfType<PlayersMovement>();

        jugador.cantidadPociones += cantPociones;            
        jugador.cantidadCofres += cantCofres;        

        jugador.dinero += cantOro;

        if (sueltaEscapulario == true)
        {
            jugador.inventario.Add("Escapulario de Elixe", 1);
        }
        
    }
}
