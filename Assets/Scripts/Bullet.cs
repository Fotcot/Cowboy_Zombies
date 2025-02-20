using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo antes de destruirse

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.linearVelocity = transform.forward.normalized * speed; // Asegura dirección correcta
        Destroy(gameObject, lifeTime); // Autodestrucci�n despu�s de un tiempo
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(20); // Hacer daño al enemigo
            }
        }

        if (other.CompareTag("Obstacle") || other.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destruir la bala si toca una pared u obstáculo
        }
    }
}
