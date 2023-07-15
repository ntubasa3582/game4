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
        //Vector3 mouseposition = Input.mousePosition;
        //mouseposition.z = 10;
        //Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);

        _text2.text = (_objectCount % _objectBlock.Length).ToString();
        _timer += Time.deltaTime; //左クリックを連続でクリックできないようにintervalをつけている
        if (_timer > _interval)
        {
            _swich = true;
            _timer = 0f;
        }
        if (obj == null)
        {
            //別のカメラで今出ているオブジェクトを撮影している
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (_swich)
            {

                _clickCount++;
                _text2.text = _clickCount.ToString("");
                clickPosition = Input.mousePosition;
                clickPosition.z = 10f;
                //if (target.y > 0)
                //{
                //左クリックを押しした時にコライダーがあったらオブジェクトを生成しない
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 
                if (hit.collider != null)
                {
                    //Debug.Log("あたり");
                }
                else
                {
                    Instantiate(_objectBlock[_objectCount % _objectBlock.Length], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[_objectCount % _objectBlock.Length].transform.rotation);
                }
                //マウスカーソルの位置にオブジェクトが生成される
                
                    //if (_objectCount == 0)
                    //{
                    //    Instantiate(_objectBlock[0], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[0].transform.rotation);
                    //    //Sprite sprite = 
                    //}
                    _swich = false;
                //}
            }
        }
        if (Input.GetMouseButtonDown(1)) //生成されるオブジェクトを変える
        {
            Debug.Log(_objectCount);
            _objectCount++;
            if (obj != null)
            {
                Destroy(obj);
            }
            //別のカメラで1つ後のオブジェクトを撮影している
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
    }
}