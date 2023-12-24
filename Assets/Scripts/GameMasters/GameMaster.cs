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
    public GameObject PauseUi;

    private void Awake()
    {
        GameTimeMaster = GetComponent<GameTimer>();
        FindObjectOfType<PlayerInputController>().OnPausePress += PauseGame;
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
        RestrictPlayer(true);
        PostGameUi.SetActive(true);
    }

    public void PauseGame()
    {
        RestrictPlayer(true);
        PauseUi.SetActive(true);
    }

    public void ResumeGame()
    {
        RestrictPlayer(false);
        GameTimeMaster.StartTimer();
        PauseUi.SetActive(false);
    }

    public void RestrictPlayer(bool shouldRestrict)
    {
        FindObjectOfType<PlayerInputController>().enabled = !shouldRestrict;
        FindObjectOfType<ThirdPersonCamera>().enabled = !shouldRestrict;
        FindObjectOfType<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = shouldRestrict ? 0f : 2f;
        FindObjectOfType<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = shouldRestrict ? 0f : 300f;
        Cursor.visible = shouldRestrict;
        Cursor.lockState = shouldRestrict ? CursorLockMode.Confined : CursorLockMode.Locked;
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