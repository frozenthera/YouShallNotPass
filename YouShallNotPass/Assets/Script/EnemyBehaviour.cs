using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : UnitBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float moveSpeed = 0.02f;
    protected float attackRate = 1f; 
    protected bool isAttackable = true;
    

    protected override void Start()
    {
        base.Start();
    }


    protected override void Update()
    {
        base.Update();
        UnitBehaviour Piece;
        if(Piece = checkGridforPiece()){    // piece is in the current Grid => fight;
            Attack(Piece);
        }else{                         // cur Grid is Empty => Move
            move();
        }

        destroyOnBoardEdge();
    }


    void move()
    {
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }


    void Attack(UnitBehaviour piece)
    {
        if(!piece.CompareTag("Piece")){
            return;
        }

        if(isAttackable){
            piece.GetDamage(attack);
            isAttackable = false;
            StartCoroutine("AttackTimer");
        }
    }


    UnitBehaviour checkGridforPiece()
    {
        if(curPos.X > -1 && curPos.X < 3 && curPos.Y > -1 && curPos.Y < 3){
            List<UnitBehaviour> thisGridMap = GameManager.Instance.pieceMap[curPos.X, curPos.Y];
            foreach(var i in thisGridMap){
                if(i.CompareTag("Piece") ){
                    return i;
                }
            }
        }
        return null;
    }


    public override void Destroyed()
    {
        GameManager.Instance.pieceMap[curPos.X, curPos.Y].Remove(this);
        Destroy(this.gameObject);
    }


    public void DestroyedonEdge()
    {
        Destroy(this.gameObject);
    }


    private IEnumerator AttackTimer()
    {           
        yield return new WaitForSeconds(attackRate);
        isAttackable = true;
    }


    private void destroyOnBoardEdge()
    {
        bool destFlg = false;
        if(moveDirection.z == 1){
            if(curPos.Y >= 3)   destFlg = true; 
        }else if(moveDirection.z == -1){
            if(curPos.Y < 0)   destFlg = true; 
        }else if(moveDirection.x == 1){
            if(curPos.X >= 3)   destFlg = true; 
        }else if(moveDirection.x == -1){
            if(curPos.X < 0)   destFlg = true; 
        }else{
            destFlg = false;
        }
        if(destFlg){
            DestroyedonEdge();
        }
    }
}
