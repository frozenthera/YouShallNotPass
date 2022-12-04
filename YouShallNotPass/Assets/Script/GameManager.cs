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

    }
}
