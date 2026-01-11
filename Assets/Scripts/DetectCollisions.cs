using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        // Находим объект ScoreManager в сцене
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            // Проверяем, является ли объект агрессивным животным
            AggressiveAnimal aggressiveAnimal = GetComponent<AggressiveAnimal>();
            if (aggressiveAnimal != null)
            {
                aggressiveAnimal.TakeDamage(1); // Наносим урон агрессивному животному
            }
            else
            {
                Destroy(gameObject); // Уничтожаем обычное животное
            }

            Destroy(other.gameObject); // Уничтожаем снаряд

            // Увеличиваем счет через ScoreManager
            scoreManager.AddScore(1);
        }
    }
}