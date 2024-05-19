using UnityEngine;
using UnityEngine.UI;

public class TriggerDungeon : MonoBehaviour
{
    public IsPressed button;
    public Spike spike;
    public GameObject boss;
    public MusicManager musicManager;
    public Image image;

    void Start()
    {
        // ��������������, ��� image ��� �������� ����� �������� Unity
        image.gameObject.SetActive(false); // ���������� ������ ����������� ����������
    }

    void Update()
    {

    }

    public void SetMusicManager(MusicManager manager)
    {
        musicManager = manager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.gameObject.SetActive(false);
            spike.isActive = true;
            boss.SetActive(true);
            musicManager.SwitchToBossMusic();
            image.gameObject.SetActive(true); // ����� ������������ �������� ������ ����������� ��������
            Destroy(this.gameObject);
        }
    }
}
