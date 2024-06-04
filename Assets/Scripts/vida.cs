using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;

    private void Start()
    {
        vida = maximoVida;
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Curar(float curacion)
    {
        if ((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }
    }
}

