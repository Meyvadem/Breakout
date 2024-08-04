using UnityEngine;

public class BallController : MonoBehaviour
{


    public float speed = 10f; // Topun hýzý
    private Vector3 direction; // Topun hareket yönü


    void Start()
    {
        // Rastgele bir baþlangýç yönü belirleyin
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

        // Çarpýþma yüzeyinin normalini al
        Vector3 normal = collision.contacts[0].normal;

        // Yeni yön = yansýma (refleksiyon)
        direction = Vector3.Reflect(direction, normal);
    }




}
