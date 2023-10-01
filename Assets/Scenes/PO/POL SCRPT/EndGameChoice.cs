using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameChoice : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    PlayerController2DPlatformer player;

    private void Awake()
    {
        player = playerObject.GetComponent<PlayerController2DPlatformer>();
    }

    void Update()
    {
        if (player.died)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
