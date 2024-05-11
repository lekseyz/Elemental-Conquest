using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public GameObject musicSource1; // Первый источник музыки (до босса)
    public GameObject musicSource2; // Второй источник музыки (босс активирован)
    public GameObject musicSource3; // Третий источник музыки (после смерти босса)

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;

    void Start()
    {
        // Получаем компоненты AudioSource
        audioSource1 = musicSource1.GetComponent<AudioSource>();
        audioSource2 = musicSource2.GetComponent<AudioSource>();
        audioSource3 = musicSource3.GetComponent<AudioSource>();

        // Включаем первую музыку при старте
        audioSource1.Play();
    }

    public void SwitchToBossMusic()
    {
        // Останавливаем текущую музыку
        audioSource1.Stop();
        // Включаем вторую музыку
        audioSource2.Play();
        // Подписываемся на событие окончания воспроизведения второй музыки,
        // чтобы переключиться на третью музыку после завершения второй
        StartCoroutine(SwitchToThirdMusicAfterSecondMusic());
    }

    IEnumerator SwitchToThirdMusicAfterSecondMusic()
    {
        yield return new WaitForSeconds(audioSource2.clip.length);
        // Останавливаем вторую музыку
        audioSource2.Stop();
        // Включаем третью музыку
        audioSource3.Play();
    }

    public void SwitchToInitialMusic()
    {
        // Останавливаем текущую музыку
        audioSource2.Stop();
        audioSource3.Stop();
        // Включаем первую музыку
        audioSource1.Play();
    }
}
