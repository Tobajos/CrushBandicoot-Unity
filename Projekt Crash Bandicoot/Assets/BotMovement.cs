using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Przesuñ bota w kierunku gracza
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, speed);

        // Obróæ bota w kierunku gracza
        Enemy.transform.LookAt(Player.transform);
    }

    void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ czy kolizja nast¹pi³a z graczem
        if (collision.gameObject == Player)
        {
            // Wywo³aj animacjê ataku
            animator.SetTrigger("Attack");
        }
    }
}
