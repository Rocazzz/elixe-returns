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
    //public GameObject enemySlot;
    public List<Heroe> listaHeroesEnBatalla = new List<Heroe>();
    public List<Enemigo> listaEnemigosEnBatalla = new List<Enemigo>();
    [SerializeField] private GameObject mensaje1, mensaje2, mensaje3, pantallaGanador, pantallaPerdedor;
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
        
    }


    public void TurnoDeAtaque(Personaje player)
    {
        if(player != null)
        {
            if (player is Heroe)
            {
                if (player.isDead == false)
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
                else
                {
                    listaHeroesEnBatalla.Remove(listaHeroesEnBatalla[turno]);
                    turno++;
                }
            }
            else if (player is Elixe)
            {
                if(!player.isDead)
                {
                    mensaje1.SetActive(false);
                    mensaje2.SetActive(false);
                    mensaje3.SetActive(false);

                    int habilidadALanzar = UnityEngine.Random.Range(0, player.listaHabilidades.Count());
                    Debug.Log("Se animo");
                    player.CambiarAnimacion("attack"+(habilidadALanzar+1));

                    player.LanzarHabilidad(habilidadALanzar);
                }
                else
                {
                    listaEnemigosEnBatalla.Remove(listaEnemigosEnBatalla[turno]);
                    turno++;

                }
            }

            else if (player is Enemigo)
            {
                if (!player.isDead)
                {
                    player.LanzarHabilidad(0);
                }
                else
                {
                    listaEnemigosEnBatalla.Remove(listaEnemigosEnBatalla[turno]);
                    turno++;
                }
            }
        }
        else
        {
            turno++;
        }
    }

    public void IniciarBatalla()
    {
        
        turno = 0;
        mensaje1.SetActive(false);
        mensaje2.SetActive(false);
        mensaje3.SetActive(false);

        pantallaGanador.SetActive(false);
        pantallaPerdedor.SetActive(false);
        

        foreach (Heroe hero in FindFirstObjectByType<PlayersMovement>().GetComponentsInChildren<Heroe>())
        {
            listaHeroesEnBatalla.Add(hero);
        }

        foreach (Enemigo enemy in FindObjectsOfType<Enemigo>())
        {
            listaEnemigosEnBatalla.Add(enemy);
        }

        ActualizarTurno();
    }

    public bool CheckHeroesConVida()
    {
        int cant = 0;
        foreach(Personaje p in listaHeroesEnBatalla)
        {
            if(listaHeroesEnBatalla.Count > 0)
            {
                if (p.vida >= 0)
                {
                    cant++;
                }
            }
        }

        if (cant > 0)
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
            if(listaEnemigosEnBatalla.Count > 0)
            {
                if (p.vida >= 0)
                {
                    cant++;
                }
            }
        }

        if (cant > 0)
        {
            
            return true;
        }
        
        return false;
    }

    public void TerminarBatalla() {
        mensaje1.SetActive(false);
        mensaje2.SetActive(false);
        mensaje3.SetActive(false);

        foreach(Heroe heroe in listaHeroesEnBatalla){
            heroe.GetComponentInChildren<Slider>().gameObject.SetActive(false);
        }

        foreach (Enemigo enemigo in listaEnemigosEnBatalla)
        {
            enemigo.GetComponentInChildren<Slider>().gameObject.SetActive(false);
        }
    }

    public void ActualizarTurno()
    {
        if (CheckHeroesConVida() && CheckEnemigosConVida())
        {
            if (turno == 0 || turno < listaHeroesEnBatalla.Count)
            {
                TurnoDeAtaque(listaHeroesEnBatalla[turno]);
            }
            else if (turno >= listaHeroesEnBatalla.Count && turno < (listaEnemigosEnBatalla.Count + listaHeroesEnBatalla.Count))
            {
                TurnoDeAtaque(listaEnemigosEnBatalla[turno - listaHeroesEnBatalla.Count]);
            }

            else if (turno - listaHeroesEnBatalla.Count >= listaEnemigosEnBatalla.Count)
            {
                turno = 0;
            }
        }
        else if (CheckHeroesConVida() && !CheckEnemigosConVida())
        {
            Debug.Log("Ganador");
            isWinner = true;
            TerminarBatalla();

            pantallaGanador.SetActive(true);
        }

        else if (!CheckHeroesConVida() && CheckEnemigosConVida())
        {
            Debug.Log("Perdedor");
            isWinner = false;
            TerminarBatalla();

            pantallaPerdedor.SetActive(true);
        }
    }
}
