using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    protected int maxHp;
    protected float currentHp;
    protected int _BaseDamage;
    protected float damage;
    private bool isAlive=true;
    float hitDelayTime;
    public virtual void Damaged(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Dead(); 
        }
    }
    protected bool IsAlive()
    {
        if (currentHp <= 0)
        {
            isAlive = false;
        }
        return isAlive;
    }

    protected virtual void Dead()
    {
        Debug.Log("Monster Dead Todo!");
        //오브젝트가 죽었을때의 실행할 함수
    }

    

}
