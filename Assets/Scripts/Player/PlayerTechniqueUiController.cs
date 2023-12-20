using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTechniqueUiController : MonoBehaviour
{
    public Image TechniqueUiOverlay;
    public TextMeshProUGUI CooldownTimerText;
    public bool IsInCooldown = false;

    public void UpdateTechniqueUiHint(bool state)
    {
        TechniqueUiOverlay.gameObject.SetActive(state);
        CooldownTimerText.gameObject.SetActive(state);
        TechniqueUiOverlay.fillAmount = state ? 1 : 0;
    }

    public void UpdateTechniqueUi(float cooldownTime)
    {
        CooldownTimerText.text = cooldownTime.ToString("0");
        TechniqueUiOverlay.fillAmount = Mathf.InverseLerp(0f, 2.5f, cooldownTime);
    }
}
