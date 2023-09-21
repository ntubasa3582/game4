using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClips;
    AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            _audioSource.PlayOneShot(_audioClips[0]);
        }
        else if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            _audioSource.PlayOneShot(_audioClips[1]);
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-1" || SceneManager.GetActiveScene().name == "GameScene1-2" || SceneManager.GetActiveScene().name == "GameScene1-3" || SceneManager.GetActiveScene().name == "GameScene1-4" || SceneManager.GetActiveScene().name == "GameScene1-5" || SceneManager.GetActiveScene().name == "GameScene1-6" || SceneManager.GetActiveScene().name == "GameScene1-7")
        {
            _audioSource.PlayOneShot(_audioClips[2]);
        }
    }
}
