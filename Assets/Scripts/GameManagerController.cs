using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerController : MonoBehaviour
{
    void Start()
    {
        AudioManagerController.Instance.LoadAudioSettings();
    }
    public void ChangeScene(string scene)
    {
        AudioManagerController.Instance.SaveAudioSettings();
        SceneManager.LoadScene(scene);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
