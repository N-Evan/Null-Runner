using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public KeySO ItemToPikcup;

    private Collider _selfCollider;

    private void Awake()
    {
        _selfCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerInventory>().AddKeyToInventory(ItemToPikcup);
            gameObject.SetActive(false);
        }
    }
}