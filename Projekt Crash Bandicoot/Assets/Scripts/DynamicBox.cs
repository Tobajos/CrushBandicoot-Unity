using UnityEngine;

public class DynamicBox : MonoBehaviour
{
    public GameObject player; // Referencja do obiektu gracza

    private bool isAttacking = false; // Flaga informuj�ca, czy gracz atakuje
    private bool isColliding = false; // Flaga informuj�ca, czy jest kolizja z graczem

    void Update()
    {
        
        Debug.Log(isAttacking);
        // Sprawd�, czy gracz atakuje
        if (isAttacking && isColliding)
        {
            Debug.Log("Attacked!");
            Destroy(gameObject); // Zniszcz skrzynk�
            isAttacking = false;
        }
    }

    // Funkcja wywo�ywana, gdy inny obiekt wejdzie w kolizj� z t� skrzynk�
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = true; // Ustaw flag� kolizji na true
        }
    }

    // Funkcja wywo�ywana, gdy inny obiekt opu�ci kolizj� z t� skrzynk�
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = false; // Ustaw flag� kolizji na false
        }
    }

    // Funkcja do ustawiania flagi ataku przez gracza
    public void SetAttacking(bool attacking)
    {
        isAttacking = attacking;
    }
}
