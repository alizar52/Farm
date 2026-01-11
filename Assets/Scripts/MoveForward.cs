using UnityEngine;

public class MoveForward1 : MonoBehaviour
{
    public float speed = 40f;
    private static float speedMultiplier = 1f; // Коэффициент для увеличения скорости

    // Устанавливаем случайную скорость при создании объекта
    void Start()
    {
        speed = Random.Range(2f, 10f) * speedMultiplier; // Увеличиваем скорость с учетом коэффициента
    }

    // Update вызывается каждый кадр
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Метод для увеличения коэффициента скорости
    public static void IncreaseSpeedMultiplier(float increment)
    {
        speedMultiplier += increment;
    }
}
