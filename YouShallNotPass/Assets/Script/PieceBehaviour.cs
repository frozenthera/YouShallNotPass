using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : UnitBehaviour
{
    [SerializeField]
    protected float attackRate = 1f; 
    [SerializeField]
    protected bool isAttackable = false;

    public UnitBehaviour target;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(AttackRateDetermine());
    }

    protected override void Update()
    {
        base.Update();
        
        UnitBehaviour target = DetermineAttackableEnemy();
        if(target != null && isAttackable)
        {
            PieceAttack(target);
        }
    }

    protected virtual UnitBehaviour DetermineAttackableEnemy() { return null;}
    protected virtual void PieceAttack(UnitBehaviour target){}

    public override void Destroyed(){}

    protected IEnumerator AttackRateDetermine()
    {
        yield return new WaitForSeconds(attackRate);
        isAttackable = true;
    }
}
