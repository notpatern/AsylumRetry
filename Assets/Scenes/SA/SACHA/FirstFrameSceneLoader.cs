using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstFrameSceneLoader : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene(1);
    }
}
