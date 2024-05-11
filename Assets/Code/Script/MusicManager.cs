using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public GameObject musicSource1; // ������ �������� ������ (�� �����)
    public GameObject musicSource2; // ������ �������� ������ (���� �����������)
    public GameObject musicSource3; // ������ �������� ������ (����� ������ �����)

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;

    void Start()
    {
        // �������� ���������� AudioSource
        audioSource1 = musicSource1.GetComponent<AudioSource>();
        audioSource2 = musicSource2.GetComponent<AudioSource>();
        audioSource3 = musicSource3.GetComponent<AudioSource>();

        // �������� ������ ������ ��� ������
        audioSource1.Play();
    }

    public void SwitchToBossMusic()
    {
        // ������������� ������� ������
        audioSource1.Stop();
        // �������� ������ ������
        audioSource2.Play();
        // ������������� �� ������� ��������� ��������������� ������ ������,
        // ����� ������������� �� ������ ������ ����� ���������� ������
        StartCoroutine(SwitchToThirdMusicAfterSecondMusic());
    }

    IEnumerator SwitchToThirdMusicAfterSecondMusic()
    {
        yield return new WaitForSeconds(audioSource2.clip.length);
        // ������������� ������ ������
        audioSource2.Stop();
        // �������� ������ ������
        audioSource3.Play();
    }

    public void SwitchToInitialMusic()
    {
        // ������������� ������� ������
        audioSource2.Stop();
        audioSource3.Stop();
        // �������� ������ ������
        audioSource1.Play();
    }
}
