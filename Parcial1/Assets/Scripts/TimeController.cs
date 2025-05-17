using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [Header("Configuración")]
    public float startTime = 60f;
    public TextMeshProUGUI timerText;       
    public GameObject defeatCanvas;

    private float currentTime;
    private bool isGameOver = false;

    void Start()
    {
        currentTime = startTime;
        defeatCanvas.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(0f, currentTime);

        UpdateTimerUI();

        if (currentTime <= 0f)
        {
            GameOver();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float extraTime)
    {
        if (!isGameOver)
        {
            currentTime += extraTime;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        defeatCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
