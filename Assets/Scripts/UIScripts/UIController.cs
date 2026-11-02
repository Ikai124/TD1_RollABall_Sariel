using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Ce script est attacher a == UI == dans la hierachy de ShowTime
    [SerializeField] private PlayerHealth playerIsFall;
    [SerializeField] private TMP_Text scoreTest;
    [SerializeField] private GameObject gameOver;

    private void Start()
    {
        UpdateScoreText(0);
    }

    void OnEnable()
    {
        playerIsFall.OnGameOver += ShowGameOver;
    }

    void OnDisable()
    {
        playerIsFall.OnGameOver -= ShowGameOver;
    }

    public void UpdateScoreText(int scoreValue)
    {
        scoreTest.text = scoreValue.ToString();
    }

    public void ShowGameOver()
    {
        // Affiche le panel gameOver et arrete le temps
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

}
