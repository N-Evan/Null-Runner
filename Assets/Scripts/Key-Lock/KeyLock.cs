using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public KeySO RequiredKey;
    public bool IsLocked;

    private void Awake()
    {
        IsLocked = true;
    }

    public void Unlock(KeySO key)
    {
        if (!IsLocked)
            return;
        if (key == RequiredKey)
        {
            Debug.Log($"Unlocked blocker!");
            //TODO remove blocker
            IsLocked = false;
            gameObject.SetActive(false);
        }
    }
}