using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] float _interval = 1f;
    [SerializeField] Text _text2;
    [Header("�N���b�N��")]
    [SerializeField] Text _clickText;
    [SerializeField] GameObject[] _objectBlock;
    //[SerializeField] GameObject _objectBlockH;
    //[SerializeField] GameObject _objectBlockW;
    //[SerializeField] GameObject _objectBlockB;
    //[SerializeField] GameObject _objectCircle;
    //[SerializeField] GameObject _objectTriangle;
    [SerializeField] GameObject _secondCamera;
    int _objectCount = 0;
    int _clickCount;
    int _clickTextCount = 0;
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
        bool animStop = false;

        _text2.text = (_objectCount % _objectBlock.Length).ToString();
        _timer += Time.deltaTime; //���N���b�N��A���ŃN���b�N�ł��Ȃ��悤��interval�����Ă���
        if (_timer > _interval)
        {
            _swich = true;
            _timer = 0f;
        }

        if (obj == null)
        {
            //�ʂ̃J�����ō��o�Ă���I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;          
        }
        else
        {
            if (obj.GetComponent<Animator>() != null && animStop == false)
            {
                obj.GetComponent<Animator>().speed = 0;
                animStop = true;
                Debug.Log(animStop);
            }
        }


        if (Input.GetMouseButtonDown(0))�@//���N���b�N
        {
            if (_swich)
            {
                clickPosition = Input.mousePosition;
                clickPosition.z = 10f;
                //if (target.y > 0)
                //{
                //���N���b�N�������������ɃR���C�_�[����������I�u�W�F�N�g�𐶐����Ȃ�
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 
                if (hit.collider != null)
                {
                    //Debug.Log("������");
                }
                else
                {
                    Instantiate(_objectBlock[_objectCount % _objectBlock.Length], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[_objectCount % _objectBlock.Length].transform.rotation);
                    _clickTextCount++;
                    _clickCount++;
                    _text2.text = _clickCount.ToString("");
                }
                //�}�E�X�J�[�\���̈ʒu�ɃI�u�W�F�N�g�����������
                
                    //if (_objectCount == 0)
                    //{
                    //    Instantiate(_objectBlock[0], Camera.main.ScreenToWorldPoint(clickPosition), _objectBlock[0].transform.rotation);
                    //    //Sprite sprite = 
                    //}
                    _swich = false;
                //}
            }
            _clickText.text = _clickCount.ToString("0");
        }
        if (Input.GetMouseButtonDown(1)) //���������I�u�W�F�N�g���V���[�g�J�b�g�ŕς���
        {
            _objectCount++;
            Debug.Log(_objectCount);
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J�����Œu����I�u�W�F�N�g���B�e���Ă��āA��ʂɕ\��
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _objectCount = 0;
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J������1��̃I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _objectCount = 1;
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J������1��̃I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _objectCount = 2;
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J������1��̃I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _objectCount = 3;
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J������1��̃I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _objectCount = 4;
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J������1��̃I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _objectCount = 5;
            if (obj != null)
            {
                Destroy(obj);
            }
            //�ʂ̃J������1��̃I�u�W�F�N�g���B�e���Ă���
            obj = Instantiate(_objectBlock[_objectCount % _objectBlock.Length], _secondCamera.transform.position + new Vector3(0, 0, 10f), Quaternion.identity, _secondCamera.transform);
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}