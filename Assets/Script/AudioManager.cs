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
        // ���y�̉��ʂ��X���C�h�o�[�̒l�ɕύX
        _audioSource.volume = newSliderValue;
    }

    private IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(_interval);
        //_audioSource.Play();
    }
}
