using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text cantMonedas, cantPociones, escapulario;

    private void Update()
    {
        cantMonedas.text = Inventario.dinero.ToString("00");
        cantPociones.text = Inventario.cantPociones.ToString("00");
        escapulario.text = Inventario.escapulario.ToString("00");
    }
}
