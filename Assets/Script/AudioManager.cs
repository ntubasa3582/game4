using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    AudioSource _audioSource;
    float _interval = 0f;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(MusicPlay());
    }
    void Update()
    {

    }

    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // 音楽の音量をスライドバーの値に変更
        _audioSource.volume = newSliderValue;
    }

    private IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(_interval);
        //_audioSource.Play();
    }
}
