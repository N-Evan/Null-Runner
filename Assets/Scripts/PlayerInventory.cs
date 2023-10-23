using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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
        if (Inventory.Count <= 0)
            return;
        var hasKey = Inventory.FirstOrDefault(x => x.KeyName == keySo.KeyName);
        if (hasKey)
        {
            OnKeyUsed?.Invoke(keySo);
            Inventory.Remove(keySo);
        }
    }
}