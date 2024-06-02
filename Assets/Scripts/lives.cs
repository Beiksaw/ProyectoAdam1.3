using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public string Lost; // Nombre de la escena a cargar cuando el jugador muera

    void Start()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;

        if (currentLives <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Player has died.");
        // Cargar la escena de Game Over
        SceneManager.LoadScene(Lost);
    }

    public void GainLife(int life)
    {
        currentLives += life;
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }
    }

    public bool IsDead()
    {
        return currentLives <= 0;
    }
}

