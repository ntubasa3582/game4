using System.Collections;
using UnityEngine;

// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVolume : MonoBehaviour
{
    AudioSource _audioSource;
    float _interval = 3f;
    private void Start()
    {
        // "AudioSource"コンポーネントを取得
        _audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(MusicPlay());
    }

    /// <summary>
    /// スライドバー値の変更イベント
    /// </summary>
    /// <param name="newSliderValue">スライドバーの値(自動的に引数に値が入る)</param>
    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // 音楽の音量をスライドバーの値に変更
        _audioSource.volume = newSliderValue;
    }

    private IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(_interval);
        _audioSource.Play();
    }
}