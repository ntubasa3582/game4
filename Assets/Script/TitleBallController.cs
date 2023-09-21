using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBallController : MonoBehaviour
{
    PauseManager2D _pauseManager = default;
    Rigidbody2D _rb;
    [Header("X座標")] 
    [SerializeField, Tooltip("X座標")] float _xpos;
    [Header("Y座標")]
    [SerializeField, Tooltip("Y座標")] float _ypos;
    //コライダーのオフセット
    const float _offset = 1.8f;
    //このオブジェクトの子オブジェクト
    GameObject _goChild;
    //子オブジェクトのCIrcleCollider2D
    CircleCollider2D _cC2D;
    Vector2 _velocity;
    Transform _transform;
    GameObject[] _posObj; //ボールの座標を記録するObject
    bool _posSwich= false;
    private void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _rb = GetComponent<Rigidbody2D>();
        _goChild = this.transform.GetChild(0).gameObject;
        _cC2D = _goChild.GetComponent<CircleCollider2D>();
        _cC2D.radius = _offset;
        _transform = GetComponent<Transform>();
        _posObj = GameObject.FindGameObjectsWithTag("Pos"); //Posタグが付いたゲームオブジェクトをSceneの中で探して取ってくる
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
        //ESCキーが押されたら動きを止める　もう一度押されたら動き出す
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

    void ResetRb() //Rigidbodyの動きを止める
    {
        _rb.Sleep();
        _rb.WakeUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //落下したらオブジェクトを初期位置に戻す
        if (collision.gameObject.tag == "DeadLine")
        {
            transform.position = new Vector2(_xpos, _ypos); 
            _rb.drag += 3;
            StartCoroutine("DragChange");
        }

    }

    public void ResetPosObject()
    {
        _posObj[0] = null; //取ってきたポジションの値を0にする
        ResetRb();
        Invoke("Swich", 0.1f);
    }

    void Swich()
    {
        _posSwich = true;
    }
}
