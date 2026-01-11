using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10f;
    public float zRange = 2f;
    public GameObject[] foodPrefabs; // Массив префабов еды
    public AudioClip throwSound; // звук выброса
    private AudioSource audioSource;


    // Update is called once per frame
    void Start()
{
    audioSource = GetComponent<AudioSource>();
}

    void Update()
    {
        // Управление движением по оси X
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Управление движением по оси Z
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // Ограничение движения по оси X
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Ограничение движения по оси Z
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        // Выстрел снаряда при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, foodPrefabs.Length);
            Instantiate(foodPrefabs[randomIndex], transform.position, foodPrefabs[randomIndex].transform.rotation);
            audioSource.pitch = Random.Range(0.8f, 1.2f); // рандомный питч
            audioSource.PlayOneShot(throwSound);
        }
    }
}
