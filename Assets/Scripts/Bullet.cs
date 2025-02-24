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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);
                BulletPool.Instance.ReturnBullet(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Wall"))
        {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }

}
