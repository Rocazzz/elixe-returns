using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heroe : Personaje
{
    // Start is called before the first frame update
    void Awake()
    {
        isDead = false;
        battleManager = FindObjectOfType<BattleManager>();
        BarraDeVida = GetComponentInChildren<Slider>();
        BarraDeVida.maxValue = vida;
        BarraDeVida.value = vida;

        foreach (Enemigo enemy in FindObjectsOfType<Enemigo>())
        {
            rivales.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UsarPocion()
    {
        if (GetComponentInParent<PlayersMovement>().cantidadPociones > 0)
        {
            vida += 20;
            if (vida >= 100)
            {
                vida = 100;
            }
            GetComponentInParent<PlayersMovement>().cantidadPociones--;
            Debug.Log($"Usaste una poci�n. Tu vida ahora es: {vida}");
            battleManager.turno++;
            battleManager.ActualizarTurno();
        }
        else
        {
            Debug.Log("No tienes pociones!");
        }
    }
}
