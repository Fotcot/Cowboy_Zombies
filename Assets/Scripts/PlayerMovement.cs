using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public Rigidbody rb;

    public float moveSpeed = 5f;

    public Camera cam;

    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.z = Input.GetAxisRaw("Vertical");
        {
            RotateTowardsMouse();
        }

        void RotateTowardsMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Plano horizontal
            float rayLength;

            if (groundPlane.Raycast(ray, out rayLength))
            {
                Vector3 pointToLook = ray.GetPoint(rayLength);
                Vector3 direction = (pointToLook - transform.position).normalized;
                direction.y = 0; // Evita que el personaje se incline

                transform.forward = direction; // Gira al personaje hacia el mouse
            }
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
    }
}
