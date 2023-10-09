using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Player playerPlayer;
    [SerializeField] private Text playerScore;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private Text bestPlayerScore;
    [SerializeField] private GameObject tryAgainScreen;

    private int score = 0;
    private bool isPlayerAlive = true;

    private void Awake()
    {
        tryAgainScreen.SetActive(false);
    }

    private void Start()
    {
        playerPlayer.OnPlayerDeath += SetPlayerDeath;
        obstacleSpawner.OnPassingTriggerBox += ManagePlayerScore;
        bestPlayerScore.text = "Best Score: " + PlayerPrefs.GetInt("PlayerScore").ToString();
    }

    private void ManagePlayerScore(object sender, System.EventArgs e)
    {
        //если игрок жив и препятствие прошло через triggerbox 

        if (isPlayerAlive)
        {
            score++;
            playerScore.text = "Your score: " + score;

            if (score >= PlayerPrefs.GetInt("PlayerScore"))
            {
                PlayerPrefs.SetInt("PlayerScore", score);
                PlayerPrefs.Save();
                bestPlayerScore.text = "Best Score: " + PlayerPrefs.GetInt("PlayerScore").ToString();
            }
        }
    }

    private void SetPlayerDeath(object sender, System.EventArgs e)
    {
        isPlayerAlive = false;
        ShowTryAgainScreen();
    }
    
    private void ShowTryAgainScreen()
    {
        tryAgainScreen.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

}
