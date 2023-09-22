using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// "AudioSource"�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�A�^�b�`
[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVolume : MonoBehaviour
{
    [SerializeField] AudioClip[] _bgm;
    AudioSource _audioSource;
    float _interval = 0f;
    bool _audioPlay = false;

    private async void Start()
    {
        // "AudioSource"�R���|�[�l���g���擾
        _audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(MusicPlay());
        //�ʂ�Scene��ǂݍ��񂾎��ɌĂ΂�郁�\�b�h��ǉ�
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
    /// �X���C�h�o�[�l�̕ύX�C�x���g
    /// </summary>
    /// <param name="newSliderValue">�X���C�h�o�[�̒l(�����I�Ɉ����ɒl������)</param>
    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // ���y�̉��ʂ��X���C�h�o�[�̒l�ɕύX
        _audioSource.volume = newSliderValue;
    }

    private IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(_interval);
        _audioSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Scene���؂�ւ�������ɉ�����悤�ɂ���
        StartCoroutine(MusicPlay());
    }
}