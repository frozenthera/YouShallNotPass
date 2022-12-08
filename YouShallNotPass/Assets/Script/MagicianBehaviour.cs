using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianBehaviour : PieceBehaviour
{
    protected override UnitBehaviour DetermineAttackableEnemy()
    {
        if(curPos.X > -1 && curPos.X < 3 && curPos.Y > -1 && curPos.Y < 3)
        {
            for(int i=-1; i<2; i++)
            {
                for(int j=-1; j<2; j++)
                {
                    if(i == 0 && j == 0 ) continue;
                    if(curPos.X +i> -1 && curPos.X +i < 3 && curPos.Y +j > -1 && curPos.Y +j < 3)
                    {
                        List<UnitBehaviour> thisGridMap = GameManager.Instance.pieceMap[curPos.X+i, curPos.Y+j];
                        foreach(var unit in thisGridMap){
                            if(unit.CompareTag("Enemy"))
                            {
                                return unit;
                            }
                        }
                    }
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
