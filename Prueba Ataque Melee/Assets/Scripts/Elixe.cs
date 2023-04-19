using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elixe : Enemigo
{
    [SerializeField] private Transform[] minionSlots = new Transform[3];

    public void InvocarSubditos()
    {
        foreach (var slot in minionSlots)
        {
            
        }
    }
}
