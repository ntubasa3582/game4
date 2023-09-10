using UnityEngine;
using UnityEngine.Events;

public class ObjectEvent : MonoBehaviour
{
    [SerializeField] UnityEvent _action;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        { 
            Debug.Log("a");
            _action.Invoke();
        }
    }
}
