using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Vector3 forwardDir  = Vector3.forward;
    Vector3 backwardDir = -Vector3.forward;
    Vector3 rightDir    = Vector3.right;
    Vector3 leftDir     = Vector3.left;


    public EnemyBehaviour enemyPrefab;
    public List<Transform> spawnTransformList;  // spawn points
    private float enemyDamage = 1f;
    private float enemySpeed = 1f;



    /*
    position        
        0   1   2       --> (x)
    11  @   @   @   3
    10  @   @   @   4
    9   @   @   @   5
        8   7   6
     
            |
            |
          camera(z)
    */



    // Start is called before the first frame update
    void Start()
    {
        SpawnatPosition(0);
        SpawnatPosition(10);
        SpawnatPosition(8);
        SpawnatPosition(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnatPosition(int position)
    {
        // spawn point
        Transform spawnTransform = spawnTransformList[position];

        // enemy direction

        // spawn enemy
        EnemyBehaviour newEnemy = Instantiate(enemyPrefab, spawnTransform );

        newEnemy.damage = enemyDamage;
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
}
