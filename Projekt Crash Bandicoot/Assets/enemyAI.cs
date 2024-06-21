using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Referencja do obiektu gracza
    private float chaseRange = 20f; // Odleg�o��, z kt�rej przeciwnik zacznie �ciga� gracza
    private float attackRange = 5f; // Odleg�o��, z kt�rej przeciwnik zacznie atakowa� gracza 2.7
    private float maxChaseDistance = 200f; // Maksymalna odleg�o��, jak� przeciwnik mo�e przebiec
    public int KnockbackForce;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 initialPosition; // Pocz�tkowa pozycja przeciwnika
    private Vector3 playerposition;
    private bool isChasing = false;

    public Transform teleportTarget;
    public GameObject targetObject;
    private bool isAttacking = false;
    private bool isColliding = false;

    private Vector3 initialPosition2;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position; // Zapisanie pocz�tkowej pozycji przeciwnika
        
        if (navMeshAgent == null)
        {
            UnityEngine.Debug.LogError("Brak komponentu NavMeshAgent na obiekcie przeciwnika.");
        }

        if (animator == null)
        {
            UnityEngine.Debug.LogError("Brak komponentu Animator na obiekcie przeciwnika.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        //UnityEngine.Debug.Log("OnTriggerEnter called");
        if(other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("TAG PLAYER WORKS");
        }


/*        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;
            int playerHealth = playerInventory.OnHealthDecrese(1, knockbackDirection);
            //UnityEngine.Debug.Log(playerHealth);
            //int playerHealth = 3;
            UnityEngine.Debug.Log(knockbackDirection);
           
            if (playerHealth == 0)
            {
                other.transform.position = teleportTarget.transform.position;
                playerInventory.Health = 3;
            }

        }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = false;
        }
    }

    void Update()
    {


        if (isAttacking && isColliding)
        {
            animator.SetBool("isDead", true);
            navMeshAgent.isStopped = true; // Zatrzymaj poruszanie si�

            StartCoroutine(DestroyAfterDelay(10f));

            isAttacking = false;
            return;
        }


        playerposition = player.position;
        if (navMeshAgent == null || animator == null)
        {
            return; // Je�li brak komponentu, zako�cz Update
        }

        
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        float distanceFromStart = Vector3.Distance(initialPosition, transform.position);


        //UnityEngine.Debug.Log(distanceToPlayer);
        //UnityEngine.Debug.Log(chaseRange);
        if (distanceToPlayer <= chaseRange && distanceFromStart <= maxChaseDistance)
        {
            isChasing = true;
            navMeshAgent.SetDestination(playerposition);
            
            if (distanceToPlayer <= attackRange)
            {
                // Atakowanie gracza
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttack", true);

            }
            else
            {
                // �ciganie gracza
                animator.SetBool("isRunning", true);
                animator.SetBool("isAttack", false);

                //UnityEngine.Debug.Log("sciganie"+distanceToPlayer);
            }
        }
        else
        {
            isChasing = false;
            navMeshAgent.SetDestination(initialPosition); // Powr�t do pocz�tkowej pozycji
            //UnityEngine.Debug.Log("Nic nie robi" + distanceToPlayer);
            if (distanceFromStart <= 1f)
            {
                // Zatrzymanie si�, gdy wr�ci do pocz�tkowej pozycji
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttack", false);

            }
            else
            {
                // Powr�t do pocz�tkowej pozycji
                animator.SetBool("isRunning", true);
                animator.SetBool("isAttack", false);

            }
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void setIsAttacking(bool value)
    {
        isAttacking = value;
    }
}
