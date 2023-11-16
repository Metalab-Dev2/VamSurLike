using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerState : MonoBehaviour
{
    public Vector2 front;
    public float base_MoveSpeed;
    public float moveSpeed;
    public UnityEvent OnInputSpace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnInputSpace.Invoke();
        }
    }
}
