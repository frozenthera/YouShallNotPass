using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : UnitBehaviour
{
    private float curAttackRate = 0f;
    protected float attackRate = 1f; 
    protected bool isAttackable = false;
    protected List<EnemyBehaviour> InsightEnemy = new();

    protected override void Start()
    {
        base.Start();
        StartCoroutine(AttackRateDetermine());
    }

    protected void AddEnemy(EnemyBehaviour enemy)
    {
        InsightEnemy.Add(enemy);
    }

    protected void RemoveEnemy(EnemyBehaviour enemy)
    {
        InsightEnemy.Remove(enemy);
    }

    public override void Destroyed()
    {
        
    }

    private IEnumerator AttackRateDetermine()
    {
        while(true)
        {
            yield return null;
            if(!isAttackable)
            {
                curAttackRate += Time.deltaTime;
                if(curAttackRate >= attackRate)
                {
                    isAttackable = true;
                    curAttackRate = 0f;
                }
            }
        }
    }

}
