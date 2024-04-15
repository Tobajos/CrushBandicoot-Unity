using UnityEngine;

public class DynamicBox : MonoBehaviour
{
    public GameObject player; // Referencja do obiektu gracza

    private bool isAttacking = false; // Flaga informuj¹ca, czy gracz atakuje
    private bool isColliding = false; // Flaga informuj¹ca, czy jest kolizja z graczem

    void Update()
    {
        
        Debug.Log(isAttacking);
        // SprawdŸ, czy gracz atakuje
        if (isAttacking && isColliding)
        {
            Debug.Log("Attacked!");
            Destroy(gameObject); // Zniszcz skrzynkê
            isAttacking = false;
        }
    }

    // Funkcja wywo³ywana, gdy inny obiekt wejdzie w kolizjê z t¹ skrzynk¹
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = true; // Ustaw flagê kolizji na true
        }
    }

    // Funkcja wywo³ywana, gdy inny obiekt opuœci kolizjê z t¹ skrzynk¹
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = false; // Ustaw flagê kolizji na false
        }
    }

    // Funkcja do ustawiania flagi ataku przez gracza
    public void SetAttacking(bool attacking)
    {
        isAttacking = attacking;
    }
}
