using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float spawnRate = 1f;
    private float init_spawnRate = 1f;
    private float gameTimer = 0f;
    private float timer_factor = -0f; //1/20f;

    public float spawnInterval = 5f;

    [SerializeField]
    public List<UnitBehaviour>[,] pieceMap = new List<UnitBehaviour>[3,3];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Initialize();
        for(int i=0; i<3; i++)
            for(int j=0; j<3; j++)
                pieceMap[i,j] = new List<UnitBehaviour>();
    }


    private void Initialize(){
        StartCoroutine(Timer());
        init_spawnRate = 1/spawnInterval;
    }


    private void Update(){
        updateSpawnRate();
    }


    private void updateSpawnRate(){
        // spawn Rate Change Logic
        spawnRate = init_spawnRate + (gameTimer * timer_factor);
    }


    private IEnumerator Timer()
    {
        while(true)
        {
            yield return null;
            gameTimer += Time.deltaTime;
        }
    }
}
