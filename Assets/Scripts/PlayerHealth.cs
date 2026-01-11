using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    public UIManager uiManager;
    private ScoreManager scoreManager;

    void Start()
    {
        // Находим ScoreManager в сцене
        scoreManager = FindObjectOfType<ScoreManager>();
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
            if (uiManager == null)
            {
                Debug.LogError("UIManager not found in the scene!");
            }
        }
    }

    public void DecreaseHealth()
    {
        health--;
        if (health <= 0)
        {
            if (uiManager != null && scoreManager != null)
            {
                // Передаем текущий счет в ShowGameOverScreen
                uiManager.ShowGameOverScreen(scoreManager.GetCurrentScore());
            }
            else
            {
                Debug.LogError("UIManager or ScoreManager is not assigned!");
            }
        }
    }
}
