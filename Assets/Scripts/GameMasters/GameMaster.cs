using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameTimer GameTimeMaster;

    private static GameMaster _instance;

    public static GameMaster Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameMaster>();
                if (_instance == null)
                {
                    GameObject gm = new GameObject("Game Master");
                    _instance = gm.AddComponent<GameMaster>();
                    return _instance;
                }
            }
            return _instance;
        }
    }

    public GameObject PostGameUi;

    private void Awake()
    {
        GameTimeMaster = GetComponent<GameTimer>();
    }

    public void StartGame()
    {
        PostGameUi.SetActive(false);
        GameTimeMaster.StartTimer();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    [ContextMenu("End Game")]
    public void EndGame()
    {
        FindObjectOfType<PlayerInputController>().enabled = false;
        FindObjectOfType<ThirdPersonCamera>().enabled = false;
        FindObjectOfType<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0f;
        FindObjectOfType<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameTimeMaster.PauseTimer();
        PostGameUi.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}