using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //Se deben añadir los heroes, el enemigo
    [SerializeField] private GameObject enemigo;


    // Start is called before the first frame update
    void Start()
    {
        IniciarBatalla();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarBatalla()
    {
        enemigo = FindAnyObjectByType<Enemigo>().gameObject;
        enemigo.transform.position = new Vector3(5, -2, 0);
    }
}
