using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples { get; private set; }

    public int Health { get; set; } = 3;

   // public UnityEvent<PlayerInventory> OnHealthDecrese;
    //public UnityEvent<PlayerInventory> OnDiamondCollected;

    public void AppleCollected()
    {
        NumberOfApples++;
        //OnDiamondCollected.Invoke(this);
    }

    public int OnHealthDecrese()
    {
        return --Health;
    }
}