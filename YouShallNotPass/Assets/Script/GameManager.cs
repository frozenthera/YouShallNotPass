using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    public bool[,] pieceMap = new bool[3,3];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
}
