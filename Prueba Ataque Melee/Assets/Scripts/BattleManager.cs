using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Se deben añadir los heroes, el enemigo
    [SerializeField] private GameObject hero1, hero2, hero3, hero4, enemy;
    [SerializeField] private GameObject[] listaPersonajes = new GameObject[5];
    [SerializeField] private GameObject fondoMensaje;
    [SerializeField] private Text textoMensaje;
    private int turno = 0;

    // Start is called before the first frame update
    void Start()
    {
        IniciarBatalla();
        listaPersonajes = new GameObject[] {hero1, hero2, hero3, hero4, enemy};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarBatalla()
    {
        enemy = FindAnyObjectByType<Enemigo>().gameObject;
        enemy.transform.position = new Vector3(5, -2, 0);
    }
}
