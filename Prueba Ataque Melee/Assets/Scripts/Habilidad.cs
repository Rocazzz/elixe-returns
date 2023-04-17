using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : MonoBehaviour
{
    [SerializeField] private float fuerza;
    [SerializeField] private int indexDado1, indexDado2;
    [SerializeField] private Transform projectileSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float calculateDamage()
    {
        int dadoInicial = Random.Range(0, 10);
        float damage = 0;

        if(dadoInicial > 0 && dadoInicial <= 3)
        {
            //Pifia
            damage = 0;
            Debug.Log("Pifia");
        }

        else if(dadoInicial >= 4 && dadoInicial >= 9)
        {
            //Se calcula el da�o a realizar
            float num = (Random.Range(0, 10) * 10) + (Random.Range(0, 10));

            if (num > 70 && num <= 99)
            {
                damage = 0;
                Debug.Log("Pifia");
            }

            else if (num <= 70 && num >= fuerza)
            {
                damage = (Random.Range(0, indexDado1) + (Random.Range(0, indexDado2)));
            }

            else if (num < fuerza && num > 5)
            {
                damage = (Random.Range(0, indexDado1) + (Random.Range(0, indexDado2) + (Random.Range(0, 4))));
            }

            else if (num >= 0 && num <= 5)
            {
                damage = (Random.Range(0, indexDado1) + (Random.Range(0, indexDado2) + (Random.Range(0, 8))));
                Debug.Log("Critico");
            }
        }
        else if(dadoInicial == 0)
        {
            damage = (Random.Range(0, indexDado1) + (Random.Range(0, indexDado2) + (Random.Range(0, 8))));
            Debug.Log("Critico");
        }
        return damage;
    }


}
