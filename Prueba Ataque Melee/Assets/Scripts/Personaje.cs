using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Personaje : MonoBehaviour
{
    public string nombre;
    public Habilidad[] listaHabilidades;
    public float vida;
    public string armadura;
    public float indexResistencia;


    public void LanzarHabilidad(int index)
    {
        //listaHabilidades[index].Atacar();
    }

    public void TakeDamage(float cant)
    {
        if(indexResistencia < 0)
        {
            int dado = Random.Range(0, 10);

            if (dado > 7 && dado <= 9)
            {
                vida -= cant;
            }

            else if (dado > 3 && dado < 7)
            {
                vida -= Random.Range(0, indexResistencia);
            }

            else if (dado >= 0 && dado <= 3)
            {
                vida = vida - Random.Range(0, indexResistencia) - Random.Range(0, 4);
            }
        }
    }
}
