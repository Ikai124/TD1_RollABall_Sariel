using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNewScene()
    {
         SceneManager.LoadScene("LVL_2");
    }
}
