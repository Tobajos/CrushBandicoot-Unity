using UnityEngine;

public class UpwardCollisionDetection : MonoBehaviour
{
    public LayerMask collisionLayer;
    public Animator animator;

    void Update()
    {
        // Wykonaj Raycast w d� od �rodka obiektu
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, collisionLayer))
        {
            // Sprawd�, czy trafiony obiekt znajduje si� w odpowiedniej warstwie
            if (hit.collider.CompareTag("CrashBandicoot") && IsAbove(hit.point, transform.position))
            {
                // Tutaj wykonaj akcje po wykryciu kolizji z g�ry
                Debug.Log("Kolizja z g�ry!");

                // Odtw�rz animacj�
                if (animator != null)
                {
                    animator.SetTrigger("JumpedOnTop");
                }
            }
        }
    }

    // Funkcja sprawdzaj�ca, czy punkt jest nad danym obiektem
    bool IsAbove(Vector3 point, Vector3 origin)
    {
        return point.y > origin.y;
    }
}
