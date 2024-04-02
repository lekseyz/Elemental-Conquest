using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public Boss boss; // Ссылка на компонент Boss

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Проверяем, что есть ссылка на компонент Boss
            if (boss != null)
            {
                // Проверяем, что здоровье босса меньше или равно 0 (босс убит)
                if (boss.currentHealth <= 0)
                {
                    // Если босс убит и мы находимся в другой сцене, разрешаем телепортацию
                    if (SceneManager.GetActiveScene().name != boss.gameObject.scene.name)
                    {
                        // Переключаемся между сценами
                        if (SceneManager.GetActiveScene().name == "ZeroVerScene")
                            SceneManager.LoadScene("Scene1");
                        else if (SceneManager.GetActiveScene().name == "Scene1")
                            SceneManager.LoadScene("ZeroVerScene");
                    }
                    else
                    {
                        Debug.Log("Вы не можете телепортироваться в локацию с боссом!");
                    }
                }
                else
                {
                    Debug.Log("Нельзя телепортироваться, пока босс еще жив!");
                }
            }
            else
            {
                // Если ссылка на компонент Boss отсутствует, телепортация разрешена без проверки здоровья босса
                // Переключаемся между сценами
                if (SceneManager.GetActiveScene().name == "ZeroVerScene")
                    SceneManager.LoadScene("Scene1");
                else if (SceneManager.GetActiveScene().name == "Scene1")
                    SceneManager.LoadScene("ZeroVerScene");
            }
        }
    }
}
