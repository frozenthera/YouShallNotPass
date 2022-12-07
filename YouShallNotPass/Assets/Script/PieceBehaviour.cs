using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBehaviour : UnitBehaviour
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
        
        target = DetermineAttackableEnemy();
        if(target != null && isAttackable)
        {
            PieceAttack(target);
        }
    }

    protected abstract UnitBehaviour DetermineAttackableEnemy();
    protected abstract void PieceAttack(UnitBehaviour target);

    public override void Destroyed()
    {
        GameManager.Instance.pieceMap[curPos.X, curPos.Y].Remove(this);
        Destroy(this.gameObject);
    }

    protected IEnumerator AttackRateDetermine()
    {
        yield return new WaitForSeconds(attackRate);
        isAttackable = true;
    }
}
