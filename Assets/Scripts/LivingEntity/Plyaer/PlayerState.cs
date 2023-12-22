using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerState : MonoBehaviour
{
    public Vector2 front;
    public float base_MoveSpeed;
    public float moveSpeed = 2f;
    SpriteRenderer myRenderer;
    public Dictionary<GameObject, float> hitObj;
    public List<ActiveSkills> skills = new List<ActiveSkills>();
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = this.gameObject.transform.GetComponent<SpriteRenderer>();
        moveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        FlipAxis();
    }

    void FlipAxis()
    {
        if (front.x < 0&& !myRenderer.flipX )
        {
            myRenderer.flipX = true;
        }
        else if(front.x>0 && myRenderer.flipX)
        {
            myRenderer.flipX = false;
        }
    }
}
