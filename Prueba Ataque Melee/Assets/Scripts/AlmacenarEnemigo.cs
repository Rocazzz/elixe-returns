using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlmacenarEnemigo
{
    public static GameObject enemigoAlmacenado;

    public static void AlmacenarEsteEnemigo(GameObject enemigo)
    {
        enemigoAlmacenado = enemigo;
    }
}
