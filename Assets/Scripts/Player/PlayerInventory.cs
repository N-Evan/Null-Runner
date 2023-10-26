using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    public List<KeySO> Inventory;

    public UnityEvent<KeySO> OnKeyUsed;

    public void Start()
    {
        Inventory = new List<KeySO>();
    }

    public void AddKeyToInventory(KeySO keySo) => Inventory.Add(keySo);

    public void UseKeyFromInventory(KeySO keySo)
    {
        var hasKey = HasKey(keySo);
        if (hasKey)
        {
            OnKeyUsed?.Invoke(keySo);
            Inventory.Remove(keySo);
        }
    }

    public bool HasKey(KeySO key)
    {
        if (Inventory.Count <= 0)
            return false;
        var hasKey = Inventory.FirstOrDefault(x => x.KeyName == key.KeyName);
        return hasKey ? true : false;
    }

    public KeySO GetKey(KeySO key)
    {
        return Inventory.FirstOrDefault(x => x.KeyName == key.KeyName);
    }
}