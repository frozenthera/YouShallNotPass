using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Vector3 forwardDir  = Vector3.forward;
    Vector3 backwardDir = -Vector3.forward;
    Vector3 rightDir    = Vector3.right;
    Vector3 leftDir     = Vector3.left;


    public EnemyIndicator enemyIndicator;
    private float indicatorDestroyTime = 0.5f;
    public EnemyBehaviour enemyPrefab;
    public List<Transform> spawnTransformList;  // spawn points
    private float enemyDamage = 1f;
    private float enemySpeed = .01f;



    /*
    position        
        0   1   2       --> (x)
    11  @   @   @   3
    10  @   @   @   4
    9   @   @   @   5
    원점8   7   6
     
            |
            |
          camera(z)
    */



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator SpawnatPosition(int position)
    {
        // spawn point
        Transform spawnTransform = spawnTransformList[position];

        // enemy Spawn indicator
        EnemyIndicator newIndicator = Instantiate(enemyIndicator, spawnTransform);


        // wait delay(0.5s)
        yield return new WaitForSeconds(indicatorDestroyTime);
        

        // spawn enemy
        EnemyBehaviour newEnemy = Instantiate(enemyPrefab, spawnTransform.transform.localPosition * .02f, Quaternion.identity, spawnTransform.parent.parent.GetChild(0));
        // newEnemy.transform.position = new Vector3(spawnTransform.position.x, 0f, spawnTransform.position.z);
        // newEnemy.transform.localPosition = new Vector3(newEnemy.transform.position.x, 0f, newEnemy.transform.position.z);
        // newEnemy.transform.SetParent(spawnTransform.parent.parent.GetChild(0));        
        Vector3 Yposition = new Vector3(newEnemy.transform.position.x * 50f, 0f, newEnemy.transform.position.z * 50f);
        newEnemy.transform.localPosition = new Vector3(Yposition.x, 0f, Yposition.z);

        newEnemy.AssignDamage(enemyDamage);
        newEnemy.moveSpeed = enemySpeed;
        switch(position){
            case 0: case 1: case 2: 
                newEnemy.moveDirection = backwardDir;
                break;
            case 3: case 4: case 5: 
                newEnemy.moveDirection = leftDir;
                break;
            case 6: case 7: case 8: 
                newEnemy.moveDirection = forwardDir;
                break;
            case 9: case 10: case 11: 
                newEnemy.moveDirection = rightDir;
                break;
            default : // error;
                print("SpawnatPosition switch statement Error");
                break;
        }
    }


    void SpawnRand(int n)
    {
        bool[] spawnFlg = new bool[12];
        
        for(int i=0;i<n;i++){
            int rand = Random.Range(1,12);

            if(spawnFlg[rand] == false){
                StartCoroutine(SpawnatPosition(rand));
                spawnFlg[rand] = true;
            }else{
                i--;
            }
        }
    }


    private IEnumerator SpawnRoutine()
    {
        bool someFlg = true;
        while(someFlg){
            float interval = GameManager.Instance.spawnInterval;
            float rate = GameManager.Instance.spawnRate;

            SpawnRand(Mathf.FloorToInt(interval * rate));
            //print("spawnRate : " + rate);
            yield return new WaitForSeconds(interval);
        }
    }
}
