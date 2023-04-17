using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Se deben añadir los heroes, el enemigo
    [SerializeField] private Personaje hero1, hero2, hero3, hero4, enemy;
    [SerializeField] private Personaje[] listaPersonajesEnBatalla = new Personaje[4];
    [SerializeField] private GameObject mensaje1, mensaje2;
    private int turno = 0;

    // Start is called before the first frame update
    void Start()
    {
        IniciarBatalla();
        listaPersonajesEnBatalla = new Personaje[] {hero1, hero2, hero3, hero4};
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            turnoDeAtaque(listaPersonajesEnBatalla[turno]);
        }
    }

    public void turnoDeAtaque(Personaje player)
    {
        if (player.listaHabilidades.Length == 1)
        {
            mensaje1.SetActive(true);
            mensaje2.SetActive(false);
        }

        else if ( player.listaHabilidades.Length == 2)
        {
            mensaje1.SetActive(false);
            mensaje2.SetActive(true);
        }
    }

    public void IniciarBatalla()
    {
        enemy = FindAnyObjectByType<Enemigo>().GetComponent<Personaje>();
        enemy.transform.position = new Vector3(5, -2, 0);
        turno = 0;
        mensaje1.SetActive(false);
        mensaje2.SetActive(false);
    }
}
