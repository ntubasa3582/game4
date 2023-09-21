using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBallController : MonoBehaviour
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
    Transform _transform;
    GameObject[] _posObj; //�{�[���̍��W���L�^����Object
    bool _posSwich= false;
    private void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _rb = GetComponent<Rigidbody2D>();
        _goChild = this.transform.GetChild(0).gameObject;
        _cC2D = _goChild.GetComponent<CircleCollider2D>();
        _cC2D.radius = _offset;
        _transform = GetComponent<Transform>();
        _posObj = GameObject.FindGameObjectsWithTag("Pos"); //Pos�^�O���t�����Q�[���I�u�W�F�N�g��Scene�̒��ŒT���Ď���Ă���
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
        //ESC�L�[�������ꂽ�瓮�����~�߂�@������x�����ꂽ�瓮���o��
        if (isPause)
        {
            _velocity = _rb.velocity;
            _rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.velocity = _velocity;
        }
    }


    void ResetScene()
    {
        transform.position = new Vector2(_xpos, _ypos);
        ResetRb();
    }

    void ResetRb() //Rigidbody�̓������~�߂�
    {
        _rb.Sleep();
        _rb.WakeUp();
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

    public void ResetPosObject()
    {
        _posObj[0] = null; //����Ă����|�W�V�����̒l��0�ɂ���
        ResetRb();
        Invoke("Swich", 0.1f);
    }

    void Swich()
    {
        _posSwich = true;
    }
}
