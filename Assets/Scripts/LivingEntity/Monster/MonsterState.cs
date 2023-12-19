using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonsterState : LivingEntity
{
    public Dictionary<SkillBase, float> damagedTime;
    GameObject playerObj;
    PlayerState player;
    Rigidbody2D myRigidbody;
    Vector2 moveTo;
    

    void Start()
    {
        SetPlyaerInfo();
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }
    private void FixedUpdate()
    {
        CalculateMoveTo();
    }
    void CalculateMoveTo()
    {
        moveTo = (player.transform.position - this.gameObject.transform.position).normalized;
        myRigidbody.velocity = moveTo * moveSpeed;
    }
    // Start is called before the first frame update
    public void LastDamagedTime(SkillBase skill)
    {
        if (!damagedTime.ContainsKey(skill))
        {
            damagedTime.Add(skill,Time.time);
        }
        else
        {
            damagedTime[skill] = Time.time;
        }
    }
    
    public void SetPlyaerInfo()
    {
        playerObj = GameManager.instance.playerOBJ;
        player = playerObj.transform.GetComponent<PlayerState>();
    }
    protected override void Dead()
    {
        player.hitObj.Remove(this.gameObject);
        Debug.Log("Need To Add AssetBundle Unload   //  MonsterStateScript");
        Debug.Log("Need To Add DeadFunction     //  MonsterStateScript");
    }
    
}
