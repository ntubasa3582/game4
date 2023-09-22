using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVolume : MonoBehaviour
{
    [SerializeField] AudioClip[] _bgm;
    AudioSource _audioSource;
    float _interval = 0f;
    bool _audioPlay = false;

    private async void Start()
    {
        // "AudioSource"コンポーネントを取得
        _audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(MusicPlay());
        //別のSceneを読み込んだ時に呼ばれるメソッドを追加
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            _audioSource.clip = _bgm[0];
        }
        else if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            _audioSource.clip = _bgm[1];
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-1" || SceneManager.GetActiveScene().name == "GameScene1-2" || SceneManager.GetActiveScene().name == "GameScene1-3" || SceneManager.GetActiveScene().name == "GameScene1-4" || SceneManager.GetActiveScene().name == "GameScene1-5" || SceneManager.GetActiveScene().name == "GameScene1-6" || SceneManager.GetActiveScene().name == "GameScene1-7")
        {
            _audioSource.clip = _bgm[2];
        }

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Sceneが切り替わった時に音が鳴るようにした
        StartCoroutine(MusicPlay());
    }
}