using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float fireRate = 0.2f; // Tiempo entre disparos
    public float bulletSpeed = 25f;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Click izquierdo del mouse
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 targetPoint = ray.GetPoint(rayLength);
            Vector3 shootDirection = (targetPoint - firePoint.position).normalized;
            shootDirection.y = 0; // Evitar que la bala vaya hacia arriba

            GameObject bulletInstance = BulletPool.Instance.GetBullet();
            bulletInstance.transform.position = firePoint.position;
            bulletInstance.transform.rotation = Quaternion.LookRotation(shootDirection);

            Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
            rb.linearVelocity = shootDirection * bulletSpeed;
        }
    }

}
