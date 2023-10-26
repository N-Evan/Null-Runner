using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameNotificationController : MonoBehaviour
{
    public TextMeshProUGUI NotificationText;

    public void OnItemUsage(KeySO key)
    {
        NotificationText.text = $"You used the {key.KeyName} key!";
        SetupTextUi();
    }

    public void OnKeySOPickup(KeySO key)
    {
        NotificationText.text = $"You picked up the {key.name} key!";
        SetupTextUi();
    }

    public void OnGameStart()
    {
    }

    public void OnGameEnd()
    {
    }

    private void SetupTextUi()
    {
        NotificationText.gameObject.transform.localScale = Vector3.zero;
        NotificationText.gameObject.SetActive(true);
        NotificationText.gameObject.transform.DOScale(Vector3.one, 1f);
        NotificationText.gameObject.transform.DOScale(0f, 1f).SetDelay(3f).OnComplete(() =>
        {
            NotificationText.text = $"";
        });
    }
}