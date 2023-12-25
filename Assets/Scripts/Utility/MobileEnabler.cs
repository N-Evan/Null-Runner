using UnityEngine;

public class MobileEnabler : MonoBehaviour
{
    public GameObject MobileControlUi;

    public void Start()
    {
        MobileControlUi.SetActive(Application.isMobilePlatform);
    }
}
