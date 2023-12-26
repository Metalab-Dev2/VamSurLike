using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LivingEntity : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    protected int _BaseDamage;
    protected float damage;
    private bool isAlive=true;
    float hitDelayTime;
    protected UnityEvent damagedEvents;
    protected UnityEvent hitEvents;
    protected float base_MoveSpeed=2f;
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
        //������Ʈ�� �׾������� ������ �Լ�
    }

    

}
