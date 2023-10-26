using UnityEngine;
using UnityEngine.Events;

public class CollisionTriggerHandler : MonoBehaviour
{
    private Collider _collider;
    public UnityEvent OnTriggerHitEvent;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnTriggerHitEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}