using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float fireRate = 0.2f; // Tiempo entre disparos

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
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletInstance.transform.parent = null; // Asegura que no herede transformaciones


    }
}
