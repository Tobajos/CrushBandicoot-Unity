using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Referencja do obiektu gracza
    public float chaseRange = 10f; // Odleg³oœæ, z której przeciwnik zacznie œcigaæ gracza
    public float attackRange = 2f; // Odleg³oœæ, z której przeciwnik zacznie atakowaæ gracza
    public float maxChaseDistance = 20f; // Maksymalna odleg³oœæ, jak¹ przeciwnik mo¿e przebiec

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 initialPosition; // Pocz¹tkowa pozycja przeciwnika

    private bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position; // Zapisanie pocz¹tkowej pozycji przeciwnika

        if (navMeshAgent == null)
        {
            Debug.LogError("Brak komponentu NavMeshAgent na obiekcie przeciwnika.");
        }

        if (animator == null)
        {
            Debug.LogError("Brak komponentu Animator na obiekcie przeciwnika.");
        }
    }

    void Update()
    {
        if (navMeshAgent == null || animator == null)
        {
            return; // Jeœli brak komponentu, zakoñcz Update
        }

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        float distanceFromStart = Vector3.Distance(initialPosition, transform.position);

        if (distanceToPlayer <= chaseRange && distanceFromStart <= maxChaseDistance)
        {
            isChasing = true;
            navMeshAgent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange)
            {
                // Atakowanie gracza
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                // Œciganie gracza
                animator.SetBool("isRunning", true);
                animator.SetBool("isAttacking", false);
            }
        }
        else
        {
            isChasing = false;
            navMeshAgent.SetDestination(initialPosition); // Powrót do pocz¹tkowej pozycji

            if (distanceFromStart <= 1f)
            {
                // Zatrzymanie siê, gdy wróci do pocz¹tkowej pozycji
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", false);
            }
            else
            {
                // Powrót do pocz¹tkowej pozycji
                animator.SetBool("isRunning", true);
                animator.SetBool("isAttacking", false);
            }
        }
    }
}
