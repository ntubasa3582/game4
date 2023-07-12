using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] float _interval = 1f;
    [SerializeField] Text _text1;
    [SerializeField] Text _text2;
    [SerializeField] GameObject[] _objectBlock;
    //[SerializeField] GameObject _objectBlockH;
    //[SerializeField] GameObject _objectBlockW;
    //[SerializeField] GameObject _objectBlockB;
    //[SerializeField] GameObject _objectCircle;
    //[SerializeField] GameObject _objectTriangle;
    int _objectCount = 0;
    int _clickCount;
    float _timer;
    private Vector3 clickPosition;
    bool _swich = false;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectCount == 6)
        {
            _objectCount = 0;
            _text2.text = _objectCount.ToString();
        }
        _timer += Time.deltaTime;
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
                clickPosition = Input.mousePosition;
                clickPosition.z = 10f;
                if (_objectCount == 0)
                {
                    Instantiate(_objectBlock[0], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[0].transform.rotation);
                }
                else if (_objectCount == 1)
                {
                    Instantiate(_objectBlock[1], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[1].transform.rotation);
                }
                else if (_objectCount == 2)
                {
                    Instantiate(_objectBlock[2], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[2].transform.rotation);
                }
                else if (_objectCount == 3)
                {
                    Instantiate(_objectBlock[3], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[3].transform.rotation);
                }
                else if (_objectCount == 4)
                {
                    Instantiate(_objectBlock[4], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[4].transform.rotation);
                }
                else if (_objectCount == 5)
                {
                    Instantiate(_objectBlock[5], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[5].transform.rotation);
                }
                _swich = false;
                _text1.text = _clickCount.ToString();

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(_objectCount);
            _objectCount++;
            _text2.text = _objectCount.ToString("");

        }
    }
}