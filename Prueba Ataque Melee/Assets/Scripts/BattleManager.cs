using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Se deben añadir los heroes, el enemigo
    
    [SerializeField] private List<Heroe> listaHeroesEnBatalla = new List<Heroe>();
    [SerializeField] private List<Enemigo> listaEnemigosEnBatalla = new List<Enemigo>();
    [SerializeField] private GameObject mensaje1, mensaje2, mensaje3;
    public int turno = 0;
    public bool isWinner;

    // Start is called before the first frame update
    void Start()
    {
        isWinner = false;
        IniciarBatalla();
    }

    // Update is called once per frame
    void Update()
    {
        if ( CheckHeroesConVida() && CheckEnemigosConVida() )
        {
            if(turno < listaHeroesEnBatalla.Count)
            {
                TurnoDeAtaque(listaHeroesEnBatalla[turno]);
            }
            else if(turno >= listaHeroesEnBatalla.Count)
            {
                TurnoDeAtaque(listaEnemigosEnBatalla[turno-listaHeroesEnBatalla.Count] );
            }
            else if (turno-listaHeroesEnBatalla.Count >= listaEnemigosEnBatalla.Count)
            {
                turno = 0;
            }
        }
    }

    public void TurnoDeAtaque(Personaje player)
    {
        if(player is Heroe)
        {
            if (player.listaHabilidades.Length == 1)
            {
                mensaje1.SetActive(true);
                foreach (Boton boton in mensaje1.GetComponentsInChildren<Boton>())
                {
                    boton.personaje = player;
                }

                mensaje2.SetActive(false);
                mensaje3.SetActive(false);
            }

            else if (player.listaHabilidades.Length == 2)
            {
                mensaje1.SetActive(false);
                mensaje2.SetActive(true);
                foreach (Boton boton in mensaje2.GetComponentsInChildren<Boton>())
                {
                    boton.personaje = player;
                }
                mensaje3.SetActive(false);
            }

            else if (player.listaHabilidades.Length == 3)
            {
                mensaje1.SetActive(false);
                mensaje2.SetActive(false);
                mensaje3.SetActive(true);
                foreach (Boton boton in mensaje3.GetComponentsInChildren<Boton>())
                {
                    boton.personaje = player;
                }
                mensaje3.GetComponentInChildren<Boton>().personaje = player;
            }
        }
        else if (player is Enemigo)
        {
            //player.CambiarAnimacion();
        }
    }

    public void IniciarBatalla()
    {
        
        turno = 0;
        mensaje1.SetActive(false);
        mensaje2.SetActive(false);
        mensaje3.SetActive(false);

        foreach (Heroe hero in FindFirstObjectByType<PlayersMovement>().GetComponentsInChildren<Heroe>())
        {
            listaHeroesEnBatalla.Add(hero);
        }

        foreach (Enemigo enemy in FindObjectsOfType<Enemigo>())
        {
            listaEnemigosEnBatalla.Add(enemy);
        }
    }

    public bool CheckHeroesConVida()
    {
        int cant = 0;
        foreach(Personaje p in listaHeroesEnBatalla)
        {
            if(p.vida >= 0)
            {
                cant++;
            }
        }

        if (cant == listaHeroesEnBatalla.Count)
        {
            
            return true;
        }
        
        return false;
    }

    public bool CheckEnemigosConVida()
    {
        int cant = 0;
        foreach (Personaje p in listaEnemigosEnBatalla)
        {
            if (p.vida >= 0)
            {
                cant++;
            }
        }

        if (cant == listaEnemigosEnBatalla.Count)
        {
            
            return true;
        }
        
        return false;
    }


    public void TerminarBatalla() { 

    }
}
