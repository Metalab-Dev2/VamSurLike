using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerState : LivingEntity
{
    public Vector2 front;
    public float moveSpeed;
    SpriteRenderer myRenderer;
    public Dictionary<GameObject, float> hitObj;
    public Dictionary<string,ActiveSkills> skills = new Dictionary<string, ActiveSkills>();
    public GameObject skillObjectPrefab;
    public Dictionary<string,GameObject> skillObjects = new Dictionary<string,GameObject>();
    int level;
    int maxEXP;
    int currentEXP;
    public float hitTime=1f;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = this.gameObject.transform.GetComponent<SpriteRenderer>();
        moveSpeed = 3f;
        maxEXP = 10;
        level = 1;
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
    void LevelUp()
    {
        if (currentEXP >= maxEXP)
        {
            level++;
            MaxExpSetting();
            if (GameManager.instance.sceneManager is GameSceneManager)
            {
                GameSceneManager gameSceneManager = (GameSceneManager)GameManager.instance.sceneManager;
                gameSceneManager.UserLevelUp();
            }
        }
    }
    void MaxExpSetting()
    {
        currentEXP -= maxEXP;
        maxEXP += 10;
    }
}
