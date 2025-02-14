using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemigo : Personaje
{
    [SerializeField] private int cantPociones, cantCofres, cantOro;
    [SerializeField] private bool sueltaEscapulario;

    private void Start()
    {
        foreach (Enemigo enemigo in AlmacenarEnemigosVencidos.listaEnemigosVencidos)
        {
            if (enemigo.nombre.Equals(nombre))
            {
                Destroy(gameObject);
            }
        }
    }
    void Awake()
    {
        isDead = false;
        battleManager = FindObjectOfType<BattleManager>();
        BarraDeVida = GetComponentInChildren<Slider>();
        BarraDeVida.maxValue = vida;
        BarraDeVida.value = vida;

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
            AlmacenarUltimaPosicion.ultimaPosicion = collision.collider.transform.position;
            SceneManager.LoadScene("BatallaCon"+nombre);
            Destroy(gameObject);
        }
    }

    public void SoltarDrop()
    {
        Inventario.cantPociones += cantPociones;            
        Inventario.cantCofres += cantCofres;        

        Inventario.dinero += cantOro;

        if (sueltaEscapulario == true)
        {
            Inventario.escapulario = 1;
        }
        
    }
}
