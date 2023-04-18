using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : Personaje
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Heroe hero in FindFirstObjectByType<PlayersMovement>().GetComponentsInChildren<Heroe>())
        {
            rivales.Add(hero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("Batalla");
        }
    }
}
