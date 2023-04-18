using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuu : MonoBehaviour
{
    public void inicioJuego()
    {
        SceneManager.LoadScene("Contexto", LoadSceneMode.Single);
    }

    public void exit()
    {
        Application.Quit();
    }
}
