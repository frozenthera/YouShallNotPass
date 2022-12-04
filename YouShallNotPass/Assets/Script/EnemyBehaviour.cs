using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : UnitBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float moveSpeed = 1f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        //Debug.Log(curPos.X + ", " + curPos.Y);


        if(checkGridforPiece()){    // piece is in the current Grid => fight;
            
        }else{                         // cur Grid is Empty => Move
            move();
        }
    }

    void move()
    {
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    bool checkGridforPiece()
    {
        List<UnitBehaviour> thisGridMap = GameManager.Instance.pieceMap[curPos.X, curPos.Y];
        
        foreach(var i in thisGridMap){
            if(i.CompareTag("Piece") ){
                return true;
            }
        }

        return false;
    }

    public override void Destroyed()
    {
        
    }


}
