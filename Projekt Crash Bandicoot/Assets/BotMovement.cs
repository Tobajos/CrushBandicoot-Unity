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
        // Przesu� bota w kierunku gracza
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, speed);

        // Obr�� bota w kierunku gracza
        Enemy.transform.LookAt(Player.transform);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Sprawd� czy kolizja nast�pi�a z graczem
        if (collision.gameObject == Player)
        {
            // Wywo�aj animacj� ataku
            animator.SetTrigger("Attack");
        }
    }
}
