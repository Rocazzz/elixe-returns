using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscenaFinal : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    public string scene;
    private bool isPlayerInRange;
     private bool didDialogueStart;

    void Update()
    {
        if(isPlayerInRange && !didDialogueStart)
        {
            didDialogueStart = true;
            dialogueMark.SetActive(true);
        }

    

        if(isPlayerInRange && Input.GetButtonDown("Fire1") && didDialogueStart)
        {
            SceneManager.LoadScene(scene);
        } 
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
