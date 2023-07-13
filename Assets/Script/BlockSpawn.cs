using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] float _interval = 1f; 
    [SerializeField] Text _text2;
    [SerializeField] GameObject[] _objectBlock;
    //[SerializeField] GameObject _objectBlockH;
    //[SerializeField] GameObject _objectBlockW;
    //[SerializeField] GameObject _objectBlockB;
    //[SerializeField] GameObject _objectCircle;
    //[SerializeField] GameObject _objectTriangle;
    [SerializeField] GameObject _secondCamera;
    int _objectCount = 0;
    int _clickCount;
    float _timer;
    private Vector3 clickPosition;
    bool _swich = false;
    GameObject obj;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (_objectCount == 6)
        //{-
        //    _objectCount = 0;
        //    
        //}
        _text2.text = (_objectCount % _objectBlock.Length).ToString();
        _timer += Time.deltaTime; //左クリックを連打できないようにintervalをつけている
        if (_timer > _interval)
        {
            _swich = true;
            _timer = 0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (_swich)
            {
                _clickCount++;
                _text2.text = _clickCount.ToString("");
                clickPosition = Input.mousePosition;
                clickPosition.z = 10f;
                //マウスカーソルの位置にオブジェクトが生成される
                Instantiate(_objectBlock[_objectCount % _objectBlock.Length], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[_objectCount % _objectBlock.Length].transform.rotation);
                //if (_objectCount == 0)
                //{
                //    Instantiate(_objectBlock[0], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[0].transform.rotation);
                //    //Sprite sprite = 
                //}
                //else if (_objectCount == 1)
                //{
                //    Instantiate(_objectBlock[1], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[1].transform.rotation);
                //}
                //else if (_objectCount == 2)
                //{
                //    Instantiate(_objectBlock[2], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[2].transform.rotation);
                //}
                //else if (_objectCount == 3)
                //{
                //    Instantiate(_objectBlock[3], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[3].transform.rotation);
                //}
                //else if (_objectCount == 4)
                //{
                //    Instantiate(_objectBlock[4], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[4].transform.rotation);
                //}
                //else if (_objectCount == 5)
                //{
                //    Instantiate(_objectBlock[5], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[5].transform.rotation);
                //}
                _swich = false;
                if (obj != null)
                {
                    Destroy(obj);
                }
                //別のカメラで今出ているオブジェクトを撮影している
                obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
                obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
        if (Input.GetMouseButtonDown(1)) //左クリックで出るオブジェクトを右クリックで変えている
        {
            Debug.Log(_objectCount);
            _objectCount++;
        }
    }
}