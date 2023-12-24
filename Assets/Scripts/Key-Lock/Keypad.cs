using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public KeyLock TargetLock;
    private KeySO _requiredKey;

    public UnityEvent<KeySO> OnKeypadInteraction;

    private void Start()
    {
        _requiredKey = TargetLock.RequiredKey;
    }

    public void Interact(KeySO key)
    {
        if (!TargetLock.IsLocked)
            return;

        TargetLock.Unlock(key);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerInv = other.gameObject.GetComponentInParent<PlayerInventory>();
            if (playerInv.HasKey(TargetLock.RequiredKey))
            {
                Interact(playerInv.GetKey(TargetLock.RequiredKey));
                OnKeypadInteraction?.Invoke(_requiredKey);
            }
        }
    }
}