using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir;
    public Boss boss; // ссылка на вашего босса
    public float damageAmount = 20f; // количество урона, наносимого огненным шаром

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Boss boss = other.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(damageAmount); // вызываем метод TakeDamage на боссе
            }
        }
        else if (other.gameObject.CompareTag("Lava") || other.gameObject.CompareTag("Player") || other.gameObject.layer <= 1)
        {
            // Ќичего не делаем, если объект не €вл€етс€ интерактивным и не наносит урон
            return;
        }

        Destroy(gameObject); // ”ничтожаем огненный шар в любом случае
    }
}
