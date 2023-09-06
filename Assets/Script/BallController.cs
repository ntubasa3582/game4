using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    PauseManager2D _pauseManager = default;
    Rigidbody2D _rb;
    [Header("X���W")] 
    [SerializeField, Tooltip("X���W")] float _xpos;
    [Header("Y���W")]
    [SerializeField, Tooltip("Y���W")] float _ypos;
    //�R���C�_�[�̃I�t�Z�b�g
    const float _offset = 1.8f;
    //���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g
    GameObject _goChild;
    //�q�I�u�W�F�N�g��CIrcleCollider2D
    CircleCollider2D _cC2D;
    Vector2 _velocity;
    private void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _rb = GetComponent<Rigidbody2D>();
        _goChild = this.transform.GetChild(0).gameObject;
        _cC2D = _goChild.GetComponent<CircleCollider2D>();
        _cC2D.radius = _offset;
    }

    public void OnEnable()
    {
        _pauseManager.OnPauseResume += PauseResume;
        _pauseManager.OnResetScene += ResetScene;
    }

    public void OnDisable()
    {
        _pauseManager.OnPauseResume -= PauseResume;
        _pauseManager.OnResetScene -= ResetScene;
    }

    void PauseResume(bool isPause)
    {
        if (isPause)
        {
            _velocity = _rb.velocity;
            _rb.Sleep();
        }
        else
        {
            _rb.WakeUp();
            _rb.velocity = _velocity;
        }
    }

    //public void Pause()
    //{
    //    _velocity = _rb.velocity;
    //    _rb.Sleep();
    //}

    //public void Resume()
    //{
    //    _rb.WakeUp();
    //    _rb.velocity = _velocity;
    //}

    void ResetScene()
    {
        transform.position = new Vector2(_xpos, _ypos);
        _rb.drag += 3;
        StartCoroutine("DragChange");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����������I�u�W�F�N�g�������ʒu�ɖ߂�
        if (collision.gameObject.tag == "DeadLine")
        {
            transform.position = new Vector2(_xpos, _ypos); 
            _rb.drag += 3;
            StartCoroutine("DragChange");
        }
    }
    IEnumerator DragChange()
    {
        yield return new WaitForSeconds(1);
        _rb.drag -= 3;
    }
}
