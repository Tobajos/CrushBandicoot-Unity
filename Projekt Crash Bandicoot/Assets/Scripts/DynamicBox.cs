using UnityEngine;

public class DynamicBox : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem hitParticle;

    private bool isAttacking = false;
    private bool isColliding = false;

    void Update()
    {
        if (isAttacking && isColliding)
        {
            soundManager.instance.PlayBoxDestroySound();
            Instantiate(hitParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            isAttacking = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isColliding = false;
        }
    }

    public void SetAttacking(bool attacking)
    {
        isAttacking = attacking;
    }
}
