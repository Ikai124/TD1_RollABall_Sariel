using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Ce script est attaché à == GameOver == dans la Hierachy
    // Quand le joueur clique sur l'un des boutons, remet le temps de jeu et l'emmène dans la scène dite.
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Showtime");
    }

    public void ReturnToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

