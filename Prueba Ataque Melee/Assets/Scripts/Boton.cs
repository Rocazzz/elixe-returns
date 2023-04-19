using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{
    public Personaje personaje;
    public int index;
    public string escena;
    private string trigger = "attack";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RealizarAtaque()
    {
        
        personaje.CambiarAnimacion(trigger+(index+1));
        
    }

    public void UtilizarPocion()
    {
        if(personaje is Heroe)
        {
            personaje.GetComponent<Heroe>().UsarPocion();
        }
    }

    public void CambiarEscena()
    {
        if(escena != null)
        {
            SceneManager.LoadScene(escena);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
