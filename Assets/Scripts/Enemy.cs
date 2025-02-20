using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida del enemigo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Zombie recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Zombie eliminado");
        Destroy(gameObject); // Destruir el enemigo
    }
}
