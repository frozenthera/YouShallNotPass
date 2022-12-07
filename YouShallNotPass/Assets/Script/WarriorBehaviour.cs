using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBehaviour : PieceBehaviour
{
    protected override UnitBehaviour DetermineAttackableEnemy()
    {
        if(curPos.X > -1 && curPos.X < 3 && curPos.Y > -1 && curPos.Y < 3)
        {
            List<UnitBehaviour> thisGridMap = GameManager.Instance.pieceMap[curPos.X, curPos.Y];
            foreach(var i in thisGridMap){
                if(i.CompareTag("Enemy"))
                {
                    return i;
                }
            }
        }
        return null;
    }

    protected override void PieceAttack(UnitBehaviour target)
    {
        target.GetDamage(attack);
        isAttackable = false;
        StartCoroutine(AttackRateDetermine());
    }

}
