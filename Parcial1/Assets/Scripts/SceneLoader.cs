using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delayBeforeLoad = 3f;
    public string sceneToLoad = "complete_track_demo";

    void Start()
    {
        Invoke(nameof(LoadScene), delayBeforeLoad);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
