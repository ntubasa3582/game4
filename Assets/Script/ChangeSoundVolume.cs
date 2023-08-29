using System.Collections;
using UnityEngine;

// "AudioSource"�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�A�^�b�`
[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVolume : MonoBehaviour
{
    AudioSource _audioSource;
    float _interval = 3f;
    private void Start()
    {
        // "AudioSource"�R���|�[�l���g���擾
        _audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(MusicPlay());
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
}