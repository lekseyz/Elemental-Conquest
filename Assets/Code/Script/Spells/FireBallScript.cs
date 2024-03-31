using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            var interactable = other.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.applyFireBall(); // �������� ����� TakeDamage �� �����
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
