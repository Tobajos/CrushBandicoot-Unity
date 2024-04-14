using UnityEngine;

public class DynamicBox : MonoBehaviour
{
    private bool isAttacking = false;

    public void SetIsAttacking(bool value)
    {
        isAttacking = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            gameObject.SetActive(false);
        }
    }
}
