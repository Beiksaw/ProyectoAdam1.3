using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        ChangeScene();
        }
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(5); // Cambia "NextSceneName" por el nombre de la escena que deseas cargar
    }
}
