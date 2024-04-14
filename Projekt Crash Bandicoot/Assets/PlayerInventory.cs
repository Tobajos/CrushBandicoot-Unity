using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    public void AppleCollected()
    {
        NumberOfApples++;
        OnDiamondCollected.Invoke(this);
    }
}