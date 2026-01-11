using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private PlayerHealth playerHealth;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("PlayerHealth component not found on Player object!");
            }
        }
        else
        {
            Debug.LogError("Player object not found in the scene!");
        }
    }

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);

                if (playerHealth != null)
                {
                    playerHealth.DecreaseHealth();
                }
                else
                {
                    Debug.LogError("PlayerHealth is null. Cannot decrease health.");
                }
            }
        }
    }
}
