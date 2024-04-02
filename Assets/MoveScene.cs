using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public Boss boss; // ������ �� ��������� Boss

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ���������, ��� ���� ������ �� ��������� Boss
            if (boss != null)
            {
                // ���������, ��� �������� ����� ������ ��� ����� 0 (���� ����)
                if (boss.currentHealth <= 0)
                {
                    // ���� ���� ���� � �� ��������� � ������ �����, ��������� ������������
                    if (SceneManager.GetActiveScene().name != boss.gameObject.scene.name)
                    {
                        // ������������� ����� �������
                        if (SceneManager.GetActiveScene().name == "ZeroVerScene")
                            SceneManager.LoadScene("Scene1");
                        else if (SceneManager.GetActiveScene().name == "Scene1")
                            SceneManager.LoadScene("ZeroVerScene");
                    }
                    else
                    {
                        Debug.Log("�� �� ������ ����������������� � ������� � ������!");
                    }
                }
                else
                {
                    Debug.Log("������ �����������������, ���� ���� ��� ���!");
                }
            }
            else
            {
                // ���� ������ �� ��������� Boss �����������, ������������ ��������� ��� �������� �������� �����
                // ������������� ����� �������
                if (SceneManager.GetActiveScene().name == "ZeroVerScene")
                    SceneManager.LoadScene("Scene1");
                else if (SceneManager.GetActiveScene().name == "Scene1")
                    SceneManager.LoadScene("ZeroVerScene");
            }
        }
    }
}
