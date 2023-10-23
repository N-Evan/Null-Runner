using UnityEngine;

public class Keypad : MonoBehaviour
{
    public KeyLock TargetLock;

    [ContextMenu("Unlock")]
    public void Interact(KeySO key)
    {
        if (!TargetLock.IsLocked)
            return;

        TargetLock.Unlock(key);
    }
}