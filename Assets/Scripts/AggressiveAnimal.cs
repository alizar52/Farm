using UnityEngine;

public class AggressiveAnimal : MonoBehaviour
{
    [SerializeField] private int health = 3; // Количество здоровья животного

    public void TakeDamage(int damage)
    {
        health -= damage; // Уменьшаем здоровье
        if (health <= 0)
        {
            Destroy(gameObject); // Уничтожаем животное, если здоровье <= 0
        }
    }
}