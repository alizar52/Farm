using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI ScoreText; // Ссылка на текст для отображения очков
    public AudioClip gameOverMusic; // музыка при проигрыше
    private AudioSource audioSource;
    public AudioSource ambientSource; // амбиент



    void Start()
    {
        Time.timeScale = 1f;
        GameOverScreen.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }


    public void ShowGameOverScreen(int score)
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);

        // Обновляем текст с количеством очков
        ScoreText.text = "" + score;
        audioSource.clip = gameOverMusic;
        audioSource.loop = false;
        audioSource.Play();
        if (ambientSource != null && ambientSource.isPlaying)
            ambientSource.Stop();


    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
