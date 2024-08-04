using UnityEngine;

public class BallController : MonoBehaviour
{


    public float speed = 10f; // Topun h�z�
    private Vector3 direction; // Topun hareket y�n�


    void Start()
    {
        // Rastgele bir ba�lang�� y�n� belirleyin
        float randomX = Random.Range(0, 1f);
        float randomZ = Random.Range(0, 1f);
        direction = new Vector3(randomX, 0, randomZ).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxController boxController = collision.gameObject.GetComponent<BoxController>();

        if (collision.gameObject.CompareTag("Line"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }

        if (boxController != null)
        {
            boxController.TakeDamage();
        }

        // �arp��ma y�zeyinin normalini al
        Vector3 normal = collision.contacts[0].normal;

        // Yeni y�n = yans�ma (refleksiyon)
        direction = Vector3.Reflect(direction, normal);
    }




}
