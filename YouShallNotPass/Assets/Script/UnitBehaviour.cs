using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UnitBehaviour : MonoBehaviour
{
    [SerializeField]
    protected float maxHP;
    [SerializeField]
    protected float curHP;
    public Grid curPos;
    
    public int x,y;

    [SerializeField]
    protected float attack;
    
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private Transform canvasTran;
    [SerializeField]
    private Text gridText;

    [SerializeField]
    private ParticleSystem HitParticle;
    [SerializeField]
    private ParticleSystem HealParticle;

    protected virtual void Start()
    {
        curPos = new Grid(-1, -1);
        curHP = maxHP;
        canvasTran.GetComponent<Canvas>().worldCamera = Camera.main;
        UpdateHP();

    }

    protected virtual void Update()
    {
        curPos = GetCurGrid();
        UpdateCanvasToCam();

        gridText.text = $"{curHP}";
        //gridText.text = $"{x} , {y} || {transform.localPosition} || {transform.position}";
        // gridText.text = $"{transform.parent.transform.eulerAngles}";
    }

    public abstract void Destroyed();

    protected Grid GetCurGrid()
    {
        float planeSize = 10f;
        int x, y;

        x = Mathf.FloorToInt((transform.localPosition.x+planeSize/2) * 3 / planeSize);
        y = Mathf.FloorToInt((transform.localPosition.z+planeSize/2) * 3 / planeSize);

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
        //Debug.Log(name + ", " + damage);
        UpdateHP();
        HitParticle.Play();
        if(curHP <= 0) Destroyed();
    }

    public void GetHeal(float heal)
    {
        curHP += heal;
        if(curHP > maxHP) curHP = maxHP;
        HealParticle.Play();
        UpdateHP();
    }

    public void AssignDamage(float damage)
    {
        attack = damage;
    }

    public void UpdateHP()
    {
        hpBar.value = (float)curHP/maxHP;
    }

    public bool isFullHP()
    {
        return curHP == maxHP;
    }

    public void UpdateCanvasToCam()
    {
        canvasTran.LookAt(canvasTran.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        Vector3 canAng = canvasTran.eulerAngles;
        canAng = new Vector3(canAng.x, canAng.y, 0);
        canvasTran.rotation = Quaternion.Euler(canAng);
    }
}