using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Pickupable : MonoBehaviour
{
    public KeySO ItemToPikcup;

    private Collider _selfCollider;

    public UnityEvent<KeySO> OnPickup;

    private void Awake()
    {
        _selfCollider = GetComponent<Collider>();

        transform.DOMoveY(1f, 0.5f, false).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0f, 360f, 0f), 2f, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1, LoopType.Incremental);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerInventory>().AddKeyToInventory(ItemToPikcup);
            DOTween.Kill(this);
            OnPickup?.Invoke(ItemToPikcup);
            gameObject.SetActive(false);
        }
    }
}