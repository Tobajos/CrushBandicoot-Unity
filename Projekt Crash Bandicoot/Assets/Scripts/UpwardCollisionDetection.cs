using UnityEngine;

public class UpwardCollisionDetection : MonoBehaviour
{
    public LayerMask collisionLayer;
    public Animator animator;

    void Update()
    {
        // Wykonaj Raycast w dó³ od œrodka obiektu
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, collisionLayer))
        {
            // SprawdŸ, czy trafiony obiekt znajduje siê w odpowiedniej warstwie
            if (hit.collider.CompareTag("CrashBandicoot") && IsAbove(hit.point, transform.position))
            {
                // Tutaj wykonaj akcje po wykryciu kolizji z góry
                Debug.Log("Kolizja z góry!");

                // Odtwórz animacjê
                if (animator != null)
                {
                    animator.SetTrigger("JumpedOnTop");
                }
            }
        }
    }

    // Funkcja sprawdzaj¹ca, czy punkt jest nad danym obiektem
    bool IsAbove(Vector3 point, Vector3 origin)
    {
        return point.y > origin.y;
    }
}
