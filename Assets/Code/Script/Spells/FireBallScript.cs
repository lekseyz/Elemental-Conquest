using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir;
    public Boss boss; // ������ �� ������ �����
    public float damageAmount = 20f; // ���������� �����, ���������� �������� �����

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
                boss.TakeDamage(damageAmount); // �������� ����� TakeDamage �� �����
            }
        }
        else if (other.gameObject.CompareTag("Lava") || other.gameObject.CompareTag("Player") || other.gameObject.layer <= 1)
        {
            // ������ �� ������, ���� ������ �� �������� ������������� � �� ������� ����
            return;
        }

        Destroy(gameObject); // ���������� �������� ��� � ����� ������
    }
}
