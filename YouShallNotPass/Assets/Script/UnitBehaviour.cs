using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBehaviour : MonoBehaviour
{
    protected float maxHP;
    protected float curHP;
    public Grid curPos;
    protected float attack;
    
    protected virtual void Start()
    {
        curPos = new Grid(-1, -1);
    }

    protected virtual void Update()
    {
        curPos = GetCurGrid();
    }

    public abstract void Destroyed();

    protected Grid GetCurGrid()
    {
        float planeSize = 10f;
        int x, y;
        x = (int)(transform.position.x * 3 / planeSize);
        y = (int)(transform.position.z * 3 / planeSize);
        Grid updated = new Grid(x,y);
        if(updated.X != curPos.X || updated.Y != curPos.Y)
        {
            // Debug.Log(x + ", " + y + ", " + curPos.X + ", " + curPos.Y);
            if((curPos.X > -1 && curPos.Y > -1) && (curPos.X < 3 && curPos.Y < 3))
                GameManager.Instance.pieceMap[curPos.X, curPos.Y].Remove(this);
            if((x > -1 && y > -1) && (x < 3 && y < 3)) 
                GameManager.Instance.pieceMap[x, y].Add(this);
        }
        return updated;
    }

    public float GetHP()
    {
        return curHP;
    }

    public void GetDamage(float damage)
    {
        curHP -= damage;
        if(curHP < 0) Destroyed();
    }
}