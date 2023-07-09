using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private TextMeshProUGUI scoreText; 
    private void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();       
    }
    private void Start()
    {
        GameManger.instance.player.ScoreEvent.AddListener(Score);
    }
    private void Score()
    {
        scoreText.text = GameManger.instance.player.score.ToString();
    }
    public void Play()
    {
        GameManger.instance.player.score = 0;
        GameManger.instance.player.playerAttack.collider2D.enabled = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
