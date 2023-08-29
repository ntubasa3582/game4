using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �u�^�C�}�[�v���g���ăt�F�[�h�A�E�g����������R���|�[�l���g
/// �K���ȃI�u�W�F�N�g�ɒǉ����Ďg��
/// </summary>
public class FadeAnimation : MonoBehaviour
{
    /// <summary>�t�F�[�h�p Image</summary>
    [SerializeField] Image _fadeImage = default;
    /// <summary>�t�F�[�h�A�E�g�����܂łɂ����鎞�ԁi�b�j/summary>
    [SerializeField] float _fadeTime = 1;
    /// <summary>�t�F�[�h�A�E�g������������炷��/summary>
    [SerializeField] AudioClip _buzzer = default;
    float _timer = 0;
    /// <summary>true �̎��t�F�[�h����\���t���O</summary>
    bool _fade = false;

    void Update()
    {
        if (_fade)
        {
            // Image ���� Color ���擾���A���Ԃ̐i�s�ɍ��킹���A���t�@��ݒ肵�� Image �ɖ߂�
            _timer += Time.deltaTime;
            Color c = _fadeImage.color;
            c.a = _timer / _fadeTime;
            _fadeImage.color = c;

            if (_timer > _fadeTime)
            {
                // �t�F�[�h����
                OnFadeFinished();
            }
        }
    }

    /// <summary>
    /// �t�F�[�h�A�E�g���J�n����
    /// </summary>
    public void Fade()
    {
        _fade = true;
        Debug.Log("Fade �J�n");
    }

    /// <summary>
    /// �t�F�[�h�A�E�g���I��������ɌĂяo��
    /// </summary>
    void OnFadeFinished()
    {
        _fade = false;
        Debug.Log("Fade ����");
        AudioSource.PlayClipAtPoint(_buzzer, Camera.main.transform.position);
    }
}
