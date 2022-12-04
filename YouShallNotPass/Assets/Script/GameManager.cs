using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    public List<UnitBehaviour>[,] pieceMap = new List<UnitBehaviour>[3,3];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for(int i=0; i<3; i++)
            for(int j=0; j<3; j++)
                pieceMap[i,j] = new List<UnitBehaviour>();
    }
}
