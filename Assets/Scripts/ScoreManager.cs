using UnityEngine;
using TMPro; // Подключаем пространство имен для TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на UI-текст TextMeshPro
    private int currentScore = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScoreUI();
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore; // Обновляем текст на UI
    }
}