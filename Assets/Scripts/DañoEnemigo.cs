using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public string Lost; // Nombre de la escena a cargar cuando el jugador muera

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Si se encuentra el componente PlayerHealth, hacer daño al jugador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                // Verificar si el jugador ha muerto
                if (playerHealth.IsDead())
                {
                    // Cargar la escena de Game Over
                    SceneManager.LoadScene(Lost);
                }
            }
        }
    }
}