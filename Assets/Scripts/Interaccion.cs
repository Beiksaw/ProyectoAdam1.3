using UnityEngine;
using UnityEngine.UI;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel;
    public GameObject imagen;

    void Start()
    {
        panel.SetActive(false);
        imagen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            imagen.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
            imagen.SetActive(false);
        }
    }
}

