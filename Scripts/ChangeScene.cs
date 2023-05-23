using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangingScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
