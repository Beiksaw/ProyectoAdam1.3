using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int totalItemsToCollect = 5; // Número total de ítems necesarios
    private int itemsCollected = 0;
    private bool allItemsCollected = false;

    // Método llamado al recoger un ítem
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemsCollected++;
            Destroy(other.gameObject);

            if (itemsCollected >= totalItemsToCollect)
            {
                allItemsCollected = true;
            }
        }

        if (other.CompareTag("Finish") && allItemsCollected)
        {
            ChangeScene();
        }
    }

    // Método para cambiar de escena
    private void ChangeScene()
    {
        SceneManager.LoadScene(2); // Cambia "NextSceneName" por el nombre de la escena que deseas cargar
    }
}

