using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Se deben añadir los heroes, el enemigo
    
    [SerializeField] private List<Heroe> listaHeroesEnBatalla = new List<Heroe>();
    [SerializeField] private List<Enemigo> listaEnemigosEnBatalla = new List<Enemigo>();
    [SerializeField] private GameObject mensaje1, mensaje2, mensaje3;
    private int turno = 0;

    // Start is called before the first frame update
    void Start()
    {
        IniciarBatalla();
    }

    // Update is called once per frame
    void Update()
    {
        if (listaEnemigosEnBatalla.Any())
        {
            TurnoDeAtaque(listaHeroesEnBatalla[turno]);
        }
    }

    public void TurnoDeAtaque(Personaje player)
    {
        if (player.listaHabilidades.Length == 1)
        {
            mensaje1.SetActive(true);
            mensaje2.SetActive(false);
            mensaje3.SetActive(false);
        }

        else if ( player.listaHabilidades.Length == 2)
        {
            mensaje1.SetActive(false);
            mensaje2.SetActive(true);
            mensaje3.SetActive(false);
        }

        else if (player.listaHabilidades.Length == 3)
        {
            mensaje1.SetActive(false);
            mensaje2.SetActive(false);
            mensaje3.SetActive(true);
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

    public void TerminarBatalla() { 

    }
}
