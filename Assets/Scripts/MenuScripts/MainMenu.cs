using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Script ranger dans MainMenu dans la Hierarchy || ensuit lier au btn avec OnClick dans l'inspector des btn.
    public void ShowButton()
    {
        SceneManager.LoadScene("Showtime");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
