using UnityEngine;

public class DynamicBox : MonoBehaviour
{
    public GameObject player;

    private bool isAttacking = false;
    private bool isColliding = false;

    void Update()
    {
        if (isAttacking && isColliding)
        {
            Destroy(gameObject);
            isAttacking = false;
        }
    }           

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            isColliding = true;
        }
    }
                                                                                                                    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            isColliding = false;
        }
    }

    public void SetAttacking(bool attacking)
    {
        isAttacking = attacking;
    }
}
