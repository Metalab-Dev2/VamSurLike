using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    protected int hp;
    protected int damage;
    private bool isAlive=true;
    float lastHitedTime;
    float hitDelayTime;
    public virtual void Damaged(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    protected bool IsAlive()
    {
        if (hp <= 0)
        {
            isAlive = false;
        }
        return isAlive;
    }
    protected virtual void Dead()
    {
        //오브젝트가 죽었을때의 실행할 함수
    }

    

}
