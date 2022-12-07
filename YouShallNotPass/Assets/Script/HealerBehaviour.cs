using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerBehaviour : PieceBehaviour
{
    protected override UnitBehaviour DetermineAttackableEnemy()
    {
        if(curPos.X > -1 && curPos.X < 3 && curPos.Y > -1 && curPos.Y < 3)
        {
            List<UnitBehaviour> thisGridMap = GameManager.Instance.pieceMap[curPos.X, curPos.Y];
            foreach(var i in thisGridMap){
                if(i == this) continue;
                if(i.CompareTag("Piece"))
                {
                    return i;
                }
            }
        }
        return null;    
    }

    protected override void PieceAttack(UnitBehaviour target)
    {
        target.GetHeal(attack);
        isAttackable = false;
        StartCoroutine(AttackRateDetermine());
    }
}